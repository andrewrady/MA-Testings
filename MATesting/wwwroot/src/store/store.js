import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const state = {
  instructors: {},
  students: {}
}

const mutations = {
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
    axios({method: 'get', url: 'http://localhost:59614/api/instructor'})
      .then(res => {
        commit('setStudents', res.data)
      })
      .catch(err => {
        console.log(err)
      })
  }
}

export default new Vuex.Store({ state, mutations, actions })
