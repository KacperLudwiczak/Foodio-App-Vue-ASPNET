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
                >
                <span class="spinner-border spinner-border-sm me-2"></span>
                Create Item
                </button>
                <button
                type="button"
                class="btn btn-outline btn-outline border btn-sm gap-2 rounded-3 px-4 py-2"
                >
                Cancel
                </button>
            </div>
            </div>

            <div class="alert alert-danger pb-0">
            Please fix the following errors:
            <ul>
                <li>ERROR</li>
            </ul>
            </div>

            <form enctype="multipart/form-data" class="needs-validation" id="menuForm">
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
                    />
                    </div>

                    <div class="mb-3">
                    <label for="description" class="form-label text-white">Description</label>
                    <textarea
                        id="description"
                        class="form-control form-control-custom"
                        placeholder="Describe the menu item..."
                        rows="3"
                    ></textarea>
                    </div>

                    <div class="mb-3">
                    <label for="specialTag" class="form-label text-white">Special Tag (Optional)</label>
                    <input
                        id="specialTag"
                        type="text"
                        class="form-control form-control-custom"
                        placeholder="e.g., Chef's Special"
                    />
                    </div>

                    <div class="mb-3">
                    <label for="category" class="form-label text-white">Category</label>
                    <select id="category" class="form-select form-control-custom">
                        <option value="" selected disabled>--Select a category--</option>
                        <option v-for="category in CATEGORIES" :key="category">{{ category }}</option>
                    </select>
                    </div>

                    <div class="mb-3">
                    <label for="price" class="form-label text-white">Price</label>
                    <input
                        id="price"
                        class="form-control form-control-custom"
                        placeholder="Enter price"
                    />
                    </div>
                </div>
                </div>

                <div class="col-lg-5">
                <div>
                    <img
                    src=""
                    class="img-fluid w-100 mb-3 rounded"
                    style="aspect-ratio: 1/1; object-fit: cover"
                    />
                    <div class="mb-3">
                    <label for="image" class="form-label text-white">Item Image</label>
                    <input
                        id="image"
                        type="file"
                        class="form-control form-control-custom"
                        accept="image/*"
                    />
                    <div class="form-text text-white-50">
                        Leave empty to keep existing image
                    </div>
                    </div>
                </div>
                </div>
            </div>
            </form>
        </div>
        </div>
    </div>
</template>

<script setup>
import { ref } from 'vue'
import { CATEGORIES } from '@/constants/constants'
const loading = ref(false)
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
