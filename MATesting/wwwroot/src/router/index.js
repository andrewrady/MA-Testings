import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/components/Index'
import Instructor from '@/components/instructors/Instructors'
import Student from '@/components/students/Students'
import Options from '@/components/options/Options'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Index',
      component: Index
    },
    {
      path: '/instructor',
      name: 'Instructor',
      component: Instructor
    },
    {
      path: '/student',
      name: 'Student',
      component: Student
    },
    {
      path: '/settings',
      name: 'settings',
      component: Options
    }
  ]
})
