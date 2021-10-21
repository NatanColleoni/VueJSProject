import Vue from "vue";
import Router from "vue-router";
import Students from "./components/students/Students";
import Teachers from "./components/teachers/Teachers";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/students",
      nome: "Students",
      component: Students,
    },
    {
      path: "/teachers",
      nome: "Teachers",
      component: Teachers,
    },
  ],
});
