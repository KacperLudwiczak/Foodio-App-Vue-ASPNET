<template>
    <div>
        <div class="d-flex justify-content-center align-items-center" v-if="loading">
        <div
            class="spinner-grow text-success"
            style="width: 2.5rem; height: 2.5rem"
            role="status"
        >
            <span class="visually-hidden">Loading...</span>
        </div>
        </div>

        <div class="container" v-else>
        <div class="mx-auto">
            <div
            class="mb-4 border-bottom d-flex justify-content-between align-items-center py-3"
            >
            <h3 class="fw-semibold text-white">Add Menu</h3>
            <div class="d-flex gap-3">
                <button
                type="submit"
                form="menuForm"
                class="btn btn-outline btn-success btn-sm gap-2 rounded-3 px-4 py-2"
                :disabled="isProcessing"
                >
                <span v-if="isProcessing" class="spinner-border spinner-border-sm me-2"></span>
                {{ menuItemIdForUpdate ? 'Update' : 'Create' }} Item
                </button>
                <button
                type="button"
                class="btn btn-outline btn-outline border btn-sm gap-2 rounded-3 px-4 py-2"
                @click="router.push({ name: APP_ROUTE_NAMES.MENU_ITEM_LIST })"
                >
                Cancel
                </button>
            </div>
            </div>

            <div class="alert alert-warning pb-0" v-if="errorList.length > 0">
            Please fix the following errors:
            <ul>
                <li v-for="error in errorList" :key="error">{{ error }}</li>
            </ul>
            </div>

            <form enctype="multipart/form-data" class="needs-validation" id="menuForm" @submit="onFormSubmit">
            <div class="row g-4">
                <div class="col-lg-7">
                <div class="d-flex flex-column g-12">
                    <div class="mb-3">
                    <label for="name" class="form-label text-white">Item Name</label>
                    <input
                        id="name"
                        type="text"
                        class="form-control form-control-custom"
                        placeholder="Enter item name"
                        v-model="menuItemObj.name"
                    />
                    </div>

                    <div class="mb-3">
                    <label for="description" class="form-label text-white">Description</label>
                    <textarea
                        id="description"
                        class="form-control form-control-custom"
                        placeholder="Describe the menu item..."
                        rows="3"
                        v-model="menuItemObj.description"
                    ></textarea>
                    </div>

                    <div class="mb-3">
                    <label for="specialTag" class="form-label text-white">Special Tag (Optional)</label>
                    <input
                        id="specialTag"
                        type="text"
                        class="form-control form-control-custom"
                        placeholder="e.g., Chef's Special"
                        v-model="menuItemObj.specialTag"
                    />
                    </div>

                    <div class="mb-3">
                    <label for="category" class="form-label text-white">Category</label>
                    <select id="category" class="form-select form-control-custom" v-model="menuItemObj.category">
                        <option value="" selected disabled>Select a category</option>
                        <option v-for="category in CATEGORIES" :key="category">{{ category }}</option>
                    </select>
                    </div>

                    <div class="mb-3">
                    <label for="price" class="form-label text-white">Price</label>
                    <input
                        id="price"
                        class="form-control form-control-custom"
                        placeholder="Enter price"
                        v-model="menuItemObj.price"
                    />
                    </div>
                </div>
                </div>

                <div class="col-lg-5">
                <div>
                    <div class="mb-3">
                    <label for="image" class="form-label text-white">Item Image</label>
                    <input
                    id="image"
                    type="file"
                    class="form-control form-control-custom"
                    accept="image/*"
                    @change="handleFileChange"
                    />
                    <div class="form-text text-white-50">
                        Leave empty to keep existing image
                    </div>
                    </div>
                    <img
                    v-if="menuItemIdForUpdate > 0 || newUploadedImage_base64 != ''"
                    :src="newUploadedImage_base64 != '' ? newUploadedImage_base64 : CONFIG_IMAGE_URL + menuItemObj.image"
                    class="img-fluid w-100 mb-3 rounded"
                    style="aspect-ratio: 1/1; object-fit: cover"
                    />
                </div>
                </div>
            </div>
            </form>
        </div>
        </div>
    </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import menuitemService from '@/services/menuItemService'
import { CATEGORIES } from '@/constants/constants'
import { APP_ROUTE_NAMES } from '@/constants/routeNames'
import { CONFIG_IMAGE_URL } from '@/constants/config'
import { useAlert } from '@/hooks/useAlert'

const loading = ref(false)
const isProcessing = ref(false)
const errorList = reactive([])
const newUploadedImage = ref(null)
const newUploadedImage_base64 = ref('')
const formData = new FormData()
const router = new useRouter()
const route = new useRoute()
const menuItemIdForUpdate = route.params.id
const { showError, showSuccess } = useAlert()

const menuItemObj = reactive({
    name: '',
    description: '',
    specialTag: '',
    category: '',
    price: 0.0,
    image: '',
})

onMounted(async () => {
    if (!menuItemIdForUpdate) return
    loading.value = true
    try {
        const result = await menuitemService.getMenuItemById(menuItemIdForUpdate)
        Object.assign(menuItemObj, result)
    } catch (err) {
        console.log('Error while fetching menu item', err)
    } finally {
        loading.value = false
    }
})

const handleFileChange = (event) => {
    isProcessing.value = true
    const file = event.target.files[0]
    newUploadedImage.value = file
    if (file) {
        const reader = new FileReader()
        reader.onload = (event) => {
            newUploadedImage_base64.value = event.target.result
        }
        reader.readAsDataURL(file)
    }
    isProcessing.value = false
}

const onFormSubmit = async (event) => {
    event.preventDefault()
    isProcessing.value = true
    errorList.length = 0 

    if (menuItemObj.name.length < 3) {
        errorList.push('Name should be at least 3 letters long.')
    }
    if (menuItemObj.price <= 0) {
        errorList.push('Price should be greater than 0.')
    }
    if (menuItemObj.category === '') {
        errorList.push('Category must be selected.')
    }

    if (newUploadedImage.value) {
        formData.append('File', newUploadedImage.value)
    } else {
        if (menuItemIdForUpdate == 0) {
            errorList.push('Image must be uploaded.')
        }
    }

    if (!errorList.length) {
        Object.entries(menuItemObj).forEach(([key, value]) => {
            formData.append(key, value)
        })

        if (menuItemIdForUpdate == 0) {
            menuitemService
                .createMenuItem(formData)
                .then(() => {
                    showSuccess('Menu item created successfully.')
                    router.push({ name: APP_ROUTE_NAMES.MENU_ITEM_LIST })
                })
                .catch((err) => {
                    isProcessing.value = false
                    showError('Menu item create failed.')
                    console.log('Create Failed', err)
                })
        } else {
            menuitemService
                .updateMenuItem(menuItemIdForUpdate, formData)
                .then(() => {
                    showSuccess('Menu item updated successfully.')
                    router.push({ name: APP_ROUTE_NAMES.MENU_ITEM_LIST })
                })
                .catch((err) => {
                    isProcessing.value = false
                    showError('Menu item update failed.')
                    console.log('Update Failed', err)
                })
        }

        console.log(menuItemObj)
    }
    isProcessing.value = false
}
</script>

<style scoped>
.form-control-custom,
.form-select.form-control-custom {
    background-color: rgba(255, 255, 255, 0.25);
    color: #fff;
    border: 1px solid rgba(255, 255, 255, 0.35);
    border-radius: 8px;
    transition: all 0.25s ease-in-out;
    backdrop-filter: blur(8px);
}

.form-control-custom:focus,
.form-select.form-control-custom:focus {
    border-color: #28a745;
    box-shadow: 0 0 6px rgba(40, 167, 69, 0.4);
    background-color: rgba(255, 255, 255, 0.3);
    outline: none;
    color: #fff;
}

.form-control-custom::placeholder {
    color: rgba(255, 255, 255, 0.7);
}

.form-select option {
    background-color: #fff;
    color: #000;
}
</style>
