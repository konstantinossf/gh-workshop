<template>
  <div class="p-6 bg-white rounded-lg shadow-md flex flex-col items-start">
    <h2 class="text-2xl font-bold mb-4">Seed Movies</h2>
    <button
      class="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 disabled:opacity-50"
      :disabled="loading"
      @click="seedMovies"
    >
      Seed Movies
    </button>
    <div v-if="loading" class="mt-2 text-blue-500 flex items-center">
      <svg class="animate-spin h-5 w-5 mr-2 text-blue-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"><circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle><path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8v8z"></path></svg>
      Seeding in progress...
    </div>
    <div v-if="message" class="mt-2 text-green-600">{{ message }}</div>
    <div v-if="error" class="mt-2 text-red-500">{{ error }}</div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const loading = ref(false)
const message = ref('')
const error = ref('')

async function seedMovies() {
  loading.value = true
  message.value = ''
  error.value = ''
  try {
  const res = await fetch('/seed', { method: 'POST' })
    if (!res.ok) throw new Error('Failed to seed movies')
    message.value = 'Movies seeded successfully!'
  } catch (e) {
    error.value = e.message
  } finally {
    loading.value = false
  }
}
</script>
