<template>
  <div>
    <h3>Add Instructor</h3>
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
      </div>
      <br>
      <button class="btn btn-outline-primary" @click="createInstructor">Submit</button>
      <hr>
    </form>
  </div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: 'add-instructor',
  data() {
    return {
      name: '',
      rank: '',
      error: ''
    }
  },
  computed: {
    ...mapState([
      'showAdd'
    ])
  },
  methods: {
    createInstructor(event) {
      if(!this.name) {
        this.error = 'You need to enter a name'
      }
      const toggle = !this.showAdd;
      const instructor = { 'name': this.name, 'rank': this.rank}
      this.$store.dispatch('sendInstructor', instructor)
      this.$store.commit('toggleAdd', toggle);
    }
  }
}
</script>