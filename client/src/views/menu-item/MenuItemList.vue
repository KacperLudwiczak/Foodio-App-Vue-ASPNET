<template>
    <div class="container d-flex justify-content-center align-items-center no-access-container">
        Menu Items: {{ menuItems }}
    </div>
</template>

<script setup>
import menuitemService from '@/services/menuItemService'
import { ref, onMounted } from 'vue'

const menuItems = ref([])
const loading = ref(false)

const fetchMenuItems = async () => {
    loading.value = true
    try {
        menuItems.value = await menuitemService.getMenuItems()
        console.log(menuItems.value)
    } catch (error) {
        console.log('Error fetch menu items:', error)
    } finally {
        loading.value = false
    }
}

onMounted(fetchMenuItems)
</script>