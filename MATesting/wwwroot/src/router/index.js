import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/components/Index'
import Instructor from '@/components/Instructors'

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
    }
  ]
})
