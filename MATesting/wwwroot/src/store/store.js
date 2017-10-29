import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const state = {
  showAdd: false,
  instructors: {},
  students: {}
}

const mutations = {
  toggleAdd: (state, payload) => {
    state.showAdd = payload
  },
  setInstructors: (state, payload) => {
    state.instructors = payload
  },
  setStudents: (state, payload) => {
    state.students = payload
  }
}

const actions = {
  populateInstructor: ({state, commit}) => {
    axios({method: 'get', url: 'http://localhost:59614/api/instructor'})
      .then(res => {
        commit('setInstructors', res.data)
      })
      .catch(err => {
        console.log(err)
      })
  },
  populateStudents: ({state, commit}) => {
    axios({method: 'get', url: 'http://localhost:59614/api/student'})
      .then(res => {
        commit('setStudents', res.data)
      })
      .catch(err => {
        console.log(err)
      })
  },
  sendInstructor: ({state, dispatch}, payload) => {
    axios({method: 'post', url: 'http://localhost:59614/api/instructor', data: payload})
      .then(() => {
        dispatch('populateInstructor')
      })
      .catch(err => {
        console.log(err)
      })
  },
  updateInstructor: ({state, dispatch}, payload) => {
    axios({method: 'put', url: `http://localhost:59614/api/instructor/${payload.id}`, data: payload})
      .then(() => {
        dispatch('populateInstructor')
      })
      .catch(err => {
        console.log(err)
      })
  },
  deleteInstructor: ({state, dispatch}, payload) => {
    axios({method: 'delete', url: `http://localhost:59614/api/instructor/${payload}`})
      .then(() => {
        dispatch('populateInstructor')
      })
  },
  // Students
  createStudent: ({state, dispatch}, payload) => {
    axios({method: 'post', url: 'http://localhost:59614/api/student', data: payload})
      .then(() => {
        dispatch('populateStudents')
      })
      .catch(err => {
        console.log(err)
      })
  },
  updateStudent: ({state, dispatch}, payload) => {
    axios({method: 'put', url: `http://localhost:59614/api/student/${payload.id}`, data: payload})
      .then(() => {
        dispatch('populateStudents')
      })
      .catch(err => {
        console.log(err)
      })
  },
  deleteStudent: ({state, dispatch}, payload) => {
    axios({method: 'delete', url: `http://localhost:59614/api/student/${payload}`})
      .then(() => {
        dispatch('populateStudents')
      })
      .catch(err => {
        console.log(err)
      })
  }
}

export default new Vuex.Store({ state, mutations, actions })
