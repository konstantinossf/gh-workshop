<template>
  <div class="p-6 bg-white rounded-lg shadow-md">
    <div class="flex items-center mb-4">
      <h2 class="text-2xl font-bold mr-2">Movies</h2>
      <button @click="refreshMovies" :disabled="loading" class="ml-2 p-2 rounded-full bg-gray-200 hover:bg-gray-300 disabled:opacity-50" title="Refresh">
        <!-- Provided correct Heroicons refresh SVG -->
        <svg xmlns="http://www.w3.org/2000/svg" height="24" viewBox="0 0 24 24" width="24" class="h-5 w-5 text-gray-600">
          <path class="heroicon-ui" d="M6 18.7V21a1 1 0 0 1-2 0v-5a1 1 0 0 1 1-1h5a1 1 0 1 1 0 2H7.1A7 7 0 0 0 19 12a1 1 0 1 1 2 0 9 9 0 0 1-15 6.7zM18 5.3V3a1 1 0 0 1 2 0v5a1 1 0 0 1-1 1h-5a1 1 0 0 1 0-2h2.9A7 7 0 0 0 5 12a1 1 0 1 1-2 0 9 9 0 0 1 15-6.7z"/>
        </svg>
      </button>
    </div>
    <div v-if="loading" class="text-gray-500">Loading movies...</div>
    <ul v-else>
      <li v-for="movie in movies" :key="movie.Id" class="mb-2 p-2 border-b last:border-b-0 flex items-center">
        <span v-if="movie.Title" class="font-semibold">{{ movie.Title }}</span>
        <span v-else class="text-gray-400 italic">No Title</span>
        <span v-if="movie.Year" class="ml-2 text-gray-600">({{ movie.Year }})</span>
      </li>
    </ul>
    <div v-if="error" class="text-red-500 mt-2">{{ error }}</div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'

const movies = ref([])
const loading = ref(true)
const error = ref('')

async function fetchMovies() {
  loading.value = true
  error.value = ''
  try {
    const res = await fetch('/movies')
    if (!res.ok) throw new Error('Failed to fetch movies')
    movies.value = await res.json()
  } catch (e) {
    error.value = e.message
  } finally {
    loading.value = false
  }
}

function refreshMovies() {
  fetchMovies()
}

onMounted(fetchMovies)
</script>
