/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./**/*.razor",
    "./**/*.cshtml",
    "./wwwroot/**/*.html",
    "./Pages/**/*.{razor,cshtml}",
    "./Layout/**/*.razor",
    "./Components/**/*.razor"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
