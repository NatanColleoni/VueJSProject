<template>
  <div class="container">

    <Title text="Students"/>

    <div class="d-flex mb-3">
      <input class="form-control form-control-sm" type="text" placeholder="Student name" 
      v-model="name"
      v-on:keyup.enter="addStudent()"
      >

      <button class="btn btn-success ms-5" @click="addStudent()">Add new student</button>
    </div>
    

    <table class="table table-hover table-stripped">
      <thead class="table-primary">
        <th scope="col">Id</th>
        <th scope="col">Name</th>
        <th scope="col">Options</th>
      </thead>

      <tbody>
        <tr v-for="(student, index) in students" :key="index">
          <td>{{ index+1 }}</td>
          <td>{{ student.name }}</td>
          <td>
            <button class="btn btn-danger" @click="removeStudent(student)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import Title from '../shared/Title.vue'

export default {
  components: {
    Title
  },
  data() {
    return {
      name: '',
      students: []
    }
  },
  created() {
    this.$http
    .get('http://localhost:3000/students')
    .then(res => res.json())
    .then(students => this.students = students)
  },
  props: {
  },
  methods: {
    addStudent() {
      let objStudent = {
        name: this.name
      }

      this.students.push(objStudent)
      this.name = ''
    },
    removeStudent(student) {
      let index = this.students.indexOf(student)

      this.students.splice(index, 1)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
