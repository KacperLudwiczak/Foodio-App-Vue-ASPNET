<template>
  <div class="app d-flex flex-column min-vh-100">
    <div class="content container-md py-2 flex-grow-1 d-flex flex-column">
      <Header />
      <main class="flex-grow-1 mx-lg-auto w-100">
        <RouterView />
      </main>
      <Footer />
    </div>
  </div>
</template>

<script setup>
import Header from './components/layout/Header.vue'
import Footer from './components/layout/Footer.vue'
import { RouterView } from 'vue-router'
</script>

<style>
.app {
  min-height: 100vh;
  background: linear-gradient(150deg,rgba(144, 238, 144, 1) 40%, rgba(62, 180, 137, 1) 100%);
  color: #fff;
}
</style>