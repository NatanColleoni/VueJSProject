<template>
  <div v-if="!loading" class="container">
    <Title :text="`Student: ${student.name}`" :btnBack="true" />

    <table class="table table-hover table-stripped">
      <tbody>
        <tr>
          <td class="color1">Id:</td>
          <td>
            <label>{{ student.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="color1">Name:</td>
          <td>
            <label>{{ student.name }}</label>
            <input v-if="!visualize" v-model="student.name" type="text" />
          </td>
        </tr>
        <tr>
          <td class="color1">Birthdate:</td>
          <td>
            <label v-if="student.birthdate != ''">{{
              student.birthdate
            }}</label>
            <input v-if="!visualize" v-model="student.birthdate" type="text" />
          </td>
        </tr>
        <tr>
          <td class="color1">Teacher:</td>
          <td>
            <label> {{ student.teacher.name }} </label>
            <select v-if="!visualize" v-model="student.teacher.id">
              <option
                v-for="(teacher, index) in teachers"
                :key="index"
                v-bind:value="teacher.id"
              >
                {{ teacher.name }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <button @click="edit()" class="btn btn-warning">
      Edit
    </button>

    <button
      v-if="!visualize"
      @click="save(student)"
      class="btn btn-success ms-2"
    >
      Save
    </button>
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
      visualize: true,
      loading: true,
    };
  },
  created() {
    this.loadTeacher();
  },
  methods: {
    loadTeacher() {
      this.$http
        .get("http://localhost:5000/api/teachers")
        .then((res) => res.json())
        .then((teacher) => {
          this.teachers = teacher;
          this.loadStudent();
        });
    },
    loadStudent() {
      this.$http
        .get(`http://localhost:5000/api/students/${this.id}`)
        .then((res) => res.json())
        .then((student) => {
          this.student = student;
          this.loading = false;
        });
    },
    edit() {
      this.visualize = !this.visualize;
    },
    save(student) {
      let studentUpdate = {
        id: student.id,
        name: student.name,
        birthdate: student.birthdate,
        teacherid: student.teacher.id,
      };

      this.$http
        .put(
          `http://localhost:5000/api/students/${studentUpdate.id}`,
          studentUpdate
        )
        .then((res) => res.json())
        .then((this.student = student))
        .then((window.location = "http://localhost:8080/#/allstudents"));
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

table tr td {
  padding: 0;
  margin-bottom: 0px;
  text-align: left;
}
table thead th {
  padding: 0px 0px;
  text-align: left !important;
}

.table > :not(:first-child) {
  border-top: none !important;
}

.color1 {
  color: #000000;
}
</style>
