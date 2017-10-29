<template>
  <div>
    <h3>Add Student</h3>
    <div class="alert alert-danger" role="alert" v-if="error">
     {{ error }}
    </div>
    <form @click.prevent.stop>
      <div class="row">
        <div class="col">
          <input type="text" class="form-control" placeholder="Name" v-model="name">
        </div>
        <div class="col">
          <input type="text" class="form-control" placeholder="Rank" v-model="rank">
        </div>
        <div class="col">
          <input type="number" class="form-control" placeholder="Size" v-model="size">
        </div>
      </div>
      <br>
      <button class="btn btn-outline-primary" @click="createStudent">Submit</button>
      <hr>
    </form>
  </div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: 'student-add',
  data() {
    return {
      name: '',
      rank: '',
      size: '',
      error: ''
    }
  },
  computed: {
    ...mapState([
      'showAdd'
    ])
  },
  methods: {
    createStudent() {
      const toggle = !this.showAdd;
      const studentObject = { name: this.name, rank: this.rank, size: this.size }

      this.$store.dispatch('createStudent', studentObject);
      this.$store.commit('toggleAdd', toggle)
    }
  }
}
</script>
