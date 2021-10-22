<template>
  <div class="container">
    <Title text="Teachers" :btnBack="false" />

    <div class="d-flex mb-3">
      <input
        class="form-control form-control-sm"
        type="text"
        placeholder="Teacher name"
        v-model="name"
        v-on:keyup.enter="addTeacher()"
      />

      <button class="btn btn-success ms-5" @click="addTeacher()">
        Add new teacher
      </button>
    </div>

    <table class="table table-hover table-stripped">
      <thead class="table-primary">
        <th scope="col">Id</th>
        <th scope="col">Name</th>
        <th scope="col">Options</th>
      </thead>

      <tbody v-if="teachers.length">
        <tr v-for="(teacher, index) in teachers" :key="index">
          <td>{{ teacher.id }}</td>

          <router-link
            v-bind:to="`/students/${teacher.id}`"
            tag="td"
            style="cursor: pointer"
          >
            {{ teacher.name }}
          </router-link>

          <td>{{ teacher.studentsNumber }}</td>
        </tr>
      </tbody>
      <tfoot v-else>
        <p>There is no teacher registered.</p>
      </tfoot>
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
      students: [],
      name: "",
    };
  },
  created() {
    this.$http
      .get("http://localhost:30785/students")
      .then((res) => res.json())
      .then((students) => {
        (this.students = students), this.loadTeachers();
      });
  },
  props: {},
  methods: {
    getNumberOfStudentsbyTeacher() {
      this.teachers.forEach((teacher, index) => {
        teacher = {
          id: teacher.id,
          name: teacher.name,
          studentsNumber: this.students.filter(
            (student) => student.teacher.id == teacher.id
          ).length,
        };
        this.teachers[index] = teacher;
      });
    },
    loadTeachers() {
      this.$http
        .get("http://localhost:30785/teachers")
        .then((res) => res.json())
        .then((teacher) => {
          (this.teachers = teacher), this.getNumberOfStudentsbyTeacher();
        });
    },
    addTeacher() {
      let objTeacher = {
        name: this.name,
      };

      this.$http
        .post("http://localhost:30785/teachers", objTeacher)
        .then((res) => res.json())
        .then((teacher) => {
          this.teachers.push(teacher);
          this.name = "";
        });
    },
  },
};
</script>

<style scoped></style>
