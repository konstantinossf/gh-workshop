
<script setup>
import MovieList from './components/MovieList.vue'
import SeedMovies from './components/SeedMovies.vue'
</script>

<template>
  <div class="min-h-screen bg-gray-100 flex flex-col items-center justify-center">
    <div class="max-w-2xl w-full space-y-8">
      <SeedMovies />
      <MovieList />
    </div>
  </div>
</template>

<style scoped>
</style>
