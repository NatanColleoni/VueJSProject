<template>
  <div>
    <h1>{{ text }}</h1>
    <div class="mb-2">
      <button v-show="btnBack" class="btn btn-primary" @click="back()">
        Back
      </button>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    text: String,
    btnBack: Boolean,
  },
  methods: {
    back() {
      this.$router.back();
    },
  },
};
</script>

<style scoped></style>
