<template>
  <div class="container">
    <Title :text="`Student: ${student.name}`" :btnBack="true" />

    <button @click="edit(student)" class="btn btn-warning">Edit</button>

    <table class="table table-hover table-stripped">
      <tbody>
        <tr>
          <td>Id:</td>
          <td>
            <label>{{ student.id }}</label>
          </td>
        </tr>
        <tr>
          <td>Name:</td>
          <td>
            <label>{{ student.name }}</label>
            <input v-model="student.name" type="text" />
          </td>
        </tr>
        <tr>
          <td>Birthdate:</td>
          <td>
            <input v-model="student.birthdate" type="text" />
          </td>
        </tr>
        <tr>
          <td>Teacher:</td>
          <td>
            <label>{{ student.teacher.name }}</label>
            <select v-model="student.teacher">
              <option
                v-for="(teacher, index) in teachers"
                :key="index"
                v-bind:value="teacher"
              >
                {{ teacher.name }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import Title from "../shared/Title.vue";
export default {
  components: {
    Title,
  },
  data() {
    return {
      teachers: [],
      student: {},
      id: this.$route.params.student_id,
      v: true,
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/students/" + this.id)
      .then((res) => res.json())
      .then((student) => (this.student = student));

    this.$http
      .get("http://localhost:3000/teachers")
      .then((res) => res.json())
      .then((teacher) => (this.teachers = teacher));
  },
  methods: {
    edit(student) {
      let studentUpdate = {
        id: student.id,
        name: student.name,
        birthdate: student.birthdate,
        teacher: student.teacher,
      };

      this.$http.put(
        `http://localhost:3000/students/${studentUpdate.id}`,
        studentUpdate
      );
    },
  },
};
</script>

<style scoped>
input,
select {
  display: flex;
  flex-direction: column;
  margin-top: 10px;
}
</style>
