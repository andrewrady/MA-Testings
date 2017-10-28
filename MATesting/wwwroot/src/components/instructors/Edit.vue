<template>
<div class="modal fade" id="editModal">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Modal {{ instructor.name }}</h5>
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
          <input type="text" class="form-control" placeholder="Rank" v-model="currentRank">
        </div>
      </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-dismiss="modal" @click="updateInstructor">Save changes</button>
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

</template>

<script>
export default {
  name: "edit-instructor",
  props: ["instructor"],
  data() {
    return {
      currentName: '',
      currentRank: ''
    }
  },
  watch: {
    instructor() {
      this.currentName = this.instructor.name;
      this.currentRank = this.instructor.rank;
    }
  },
  methods: {
    updateInstructor(){
      const instructorObject = { 'id': this.instructor.id, 'name': this.currentName, 'rank': this.currentRank }
      this.$store.dispatch('updateInstructor', instructorObject);
    }
  }
};
</script>
