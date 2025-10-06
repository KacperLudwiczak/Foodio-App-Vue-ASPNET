<template>
    <nav class="navbar navbar-expand-md mx-auto my-2 w-100 modern-navbar">
        <div class="container-fluid">
        <router-link class="navbar-brand" :to="{ name: APP_ROUTE_NAMES.HOME }">
            <img
            src="@/assets/logo-rice-white.png"
            alt="Logo"
            height="28px"
            class="d-inline-block align-text-top me-2"
            />
            Foodio
        </router-link>

        <button
            class="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
        >
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
                <router-link class="nav-link" :to="{ name: APP_ROUTE_NAMES.ORDER_LIST }">
                Orders
                </router-link>
            </li>
            <li class="nav-item dropdown">
                <a
                class="nav-link dropdown-toggle"
                href="#"
                role="button"
                data-bs-toggle="dropdown"
                aria-expanded="false"
                >
                Admin
                </a>
                <ul class="dropdown-menu">
                <li>
                    <router-link class="dropdown-item" :to="{ name: APP_ROUTE_NAMES.MENU_ITEM_LIST }">
                    Menu Items
                    </router-link>
                </li>
                <li>
                    <router-link class="dropdown-item" :to="{ name: APP_ROUTE_NAMES.MANAGE_ORDER_ADMIN }">
                    Order Management
                    </router-link>
                </li>
                </ul>
            </li>
            </ul>

            <ul class="navbar-nav ms-auto align-items-center small">
            <li class="nav-item px-2">
                <router-link class="nav-link px-2 position-relative" :to="{ name: APP_ROUTE_NAMES.CART }">
                <i class="bi bi-cart3"></i>
                <span class="position-absolute start-100 translate-middle badge rounded-pill bg-danger">0</span>
                </router-link>
            </li>
            <li class="nav-item">
                <router-link class="nav-link" :to="{ name: APP_ROUTE_NAMES.SIGN_IN }">Sign In</router-link>
            </li>
            <li class="nav-item">
                <router-link class="nav-link" :to="{ name: APP_ROUTE_NAMES.SIGN_UP }">Sign Up</router-link>
            </li>
            <li class="nav-item">
                <button class="nav-link px-2">Logout</button>
            </li>
            </ul>
        </div>
        </div>
    </nav>
</template>

<script setup>
import { APP_ROUTE_NAMES } from '@/constants/routeNames'
</script>

<style scoped>

.modern-navbar {
    background-color: rgba(40, 167, 69, 0.25); 
    backdrop-filter: blur(10px);
    border-radius: 12px;
    box-shadow: 0 8px 20px rgba(0, 0, 0, 0.2); 
}

.modern-navbar .nav-link,
.modern-navbar .navbar-brand {
    color: #fff !important;
    font-weight: 500;
}

.modern-navbar .nav-link:hover,
.modern-navbar .navbar-brand:hover {
    color: #d4f4dd !important; 
}

.modern-navbar .dropdown-menu {
    background-color: rgba(0, 0, 0, 0.75); 
}

.modern-navbar .dropdown-item {
    color: #fff !important;
}

.modern-navbar .dropdown-item:hover {
    background-color: rgba(255, 255, 255, 0.1);
    color: #f0f0f0 !important;
}

.modern-navbar .navbar-toggler {
    border-color: rgba(255, 255, 255, 0.5);
}

.modern-navbar .navbar-toggler-icon {
    filter: invert(100%);
}

.modern-navbar .badge.bg-danger {
    background-color: #ff8800 !important;
    color: #fff;
}
</style>
