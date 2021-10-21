import Vue from "vue";
import Router from "vue-router";
import Students from "./components/students/Students";
import Teachers from "./components/teachers/Teachers";
import StudentDetails from "./components/students/StudentDetail";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/students/:prof_id",
      name: "Students",
      component: Students,
    },
    {
      path: "/teachers",
      name: "Teachers",
      component: Teachers,
    },
    {
      path: "/allstudents",
      name: "Students",
      component: Students,
    },
    {
      path: "/studentdetails/:student_id",
      name: "StudentDetails",
      component: StudentDetails,
    },
  ],
});
