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
          <input type="text" class="form-control" placeholder="Rank" v-model="step">
        </div>
      </div>
      <br>
      <button class="btn btn-outline-primary" @click="createRank">Submit</button>
      <hr>
    </form>
  </div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: 'rank-add',
  data() {
    return {
      name: '',
      step: 0,
      error: ''
    }
  },
  computed: {
    ...mapState([
      'showAdd'
    ])
  },
  methods: {
    createRank() {
      const rankObject = {name : this.name, step: this.step};

      const toggle = !this.showAdd;
      this.$store.dispatch('addRank', rankObject);
      this.$store.commit('toggleAdd', toggle);
    }
  }
};
</script>
