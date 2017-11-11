<template>
    <div class="modal fade" id="editModal">
      <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Modal {{ rank.name }}</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <div class="row">
          <div class="col">
            <input type="text" class="form-control" placeholder="Name" v-model="rank.name">
          </div>
          <div class="col">
            <input type="text" class="form-control" placeholder="Order" v-model="rank.step">
          </div>
        </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-primary" data-dismiss="modal" @click="updateRank">Save changes</button>
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
 name: 'rank-edit',
 props: ['rank'],
 methods: {
   updateRank() {
    let rankObject = { ...this.rank };
    this.$store.dispatch('updateRank', rankObject);
   }
 }
}
</script>
