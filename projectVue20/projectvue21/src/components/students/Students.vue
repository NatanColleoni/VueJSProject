<template>
  <div class="container">
    <Title
      :btnBack="false"
      :text="teacherid != undefined ? 'Teacher: ' + teacher.name : 'Students'"
    />

    <div v-if="teacherid != undefined" class="d-flex mb-3">
      <input
        class="form-control form-control-sm"
        type="text"
        placeholder="Student name"
        v-model="name"
        v-on:keyup.enter="addStudent()"
      />

      <button class="btn btn-success ms-5" @click="addStudent()">
        Add new student
      </button>
    </div>

    <table class="table table-hover table-stripped">
      <thead class="table-primary">
        <th scope="col">Id</th>
        <th scope="col">Name</th>
        <th scope="col">Options</th>
      </thead>

      <tbody v-if="students.length">
        <tr v-for="(student, index) in students" :key="index">
          <td>{{ student.id }}</td>
          <router-link
            :to="`/studentdetails/${student.id}`"
            tag="td"
            style="cursor: pointer"
          >
            {{ student.name }}</router-link
          >
          <td>
            <button class="btn btn-danger" @click="removeStudent(student)">
              Remove
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <p>There is no student registered.</p>
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
      teacherid: this.$route.params.prof_id,
      teacher: {},
      name: "",
      students: [],
    };
  },
  created() {
    if (this.teacherid) {
      this.loadTeachers();
      this.$http
        .get(`http://localhost:5000/api/students/ByTeacher/${this.teacherid}`)
        .then((res) => res.json())
        .then((students) => (this.students = students));
    } else {
      this.$http
        .get("http://localhost:5000/api/students/")
        .then((res) => res.json())
        .then((students) => (this.students = students));
    }
  },
  props: {},
  methods: {
    addStudent() {
      let objStudent = {
        name: this.name,
        birthdate: "",
        teacherid: this.teacher.id,
      };

      this.$http
        .post("http://localhost:5000/api/students", objStudent)
        .then((res) => res.json())
        .then((student) => {
          this.students.push(student);
          this.name = "";
        });
    },
    removeStudent(student) {
      this.$http
        .delete(`http://localhost:5000/api/students/${student.id}`)
        .then(() => {
          let index = this.students.indexOf(student);
          this.students.splice(index, 1);
        });
    },
    loadTeachers() {
      this.$http
        .get("http://localhost:5000/api/teachers/" + this.teacherid)
        .then((res) => res.json())
        .then((teacher) => {
          this.teacher = teacher;
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
