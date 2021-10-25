<template>
  <div id="app">
    <Nav></Nav>
    <router-view v-bind:key="$route.fullPath"></router-view>
  </div>
</template>

<script>
import Nav from "./components/nav/Nav.vue";
export default {
  name: "App",
  components: {
    Nav,
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Roboto&display=swap");

body {
  background-color: #eee;
  font-family: "Roboto", sans-serif;
  justify-items: center;
}
body,
html {
  margin: 0;
  height: 100%;
}

table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}
table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
  text-align: center;
}
table thead th {
  background-color: rgb(184, 208, 216) !important;
  /* font-size: 1.2em; */
  padding: 10px 0px;
  text-align: center !important;
}
.btn {
  padding: 10px 20px;
  cursor: pointer;
  color: white;
  font-weight: bold;
}
</style>
