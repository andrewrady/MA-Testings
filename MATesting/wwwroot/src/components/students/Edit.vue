<template>
  <div class="modal fade" id="editModal">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Modal {{ student.name }}</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="row">
        <div class="col">
          <input type="text" class="form-control" placeholder="Name" v-model="currentName">
        </div>
        <div class="col">
          <select v-model="currentRank" class="form-control">
            <option v-for="(rank, step) in ranks" :key="step" :value="rank.name">{{ rank.name }}</option>
          </select>
        </div>
        <div class="col">
          <input type="number" class="form-control" placeholder="Size" v-model="currentSize">
        </div>
      </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-dismiss="modal" @click="updateStudent">Save changes</button>
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: 'student-edit',
  props: ['student'],
  data() {
    return {
      currentName: '',
      currentRank: '',
      currentSize: ''
    }
  },
  computed: {
    ...mapState([
      'ranks'
    ])
  },
  watch: {
    student() {
      this.currentName = this.student.name;
      this.currentRank = this.student.rank;
      this.currentSize = this.student.size;
    }
  },
  mounted() {
    this.$store.dispatch('populateRanks');
  },
  methods: {
    updateStudent() {
      const studentObject = {id: this.student.id, name: this.currentName, rank: this.currentRank, size: this.currentSize };

      this.$store.dispatch('updateStudent', studentObject);
    }
  }
}
</script>
