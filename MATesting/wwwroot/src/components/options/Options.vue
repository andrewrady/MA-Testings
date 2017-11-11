<template>
  <div>
    <div class="row">
			<div class="col">
				<h2>Ranks</h2>
			</div>
			<div class="col">
				<button type="button" class="btn btn-outline-primary float-right" v-if="!showAdd" @click="toggleAdd">Add</button>
				<button type="button" class="btn btn-outline-danger float-right" v-if="showAdd" @click="toggleAdd">Close</button>
			  </div>
		  </div>
      <add v-if="showAdd"></add>
      <table class="table border">
			<thead>
				<tr>
					<th scope="col">Rank</th>
					<th scope="col">Order</th>
          <th scope="col">Edit</th>
          <td scope="col">Delete</td>
        </tr>
			</thead>
			<tbody>
				<tr v-for="(rank, index) in ranks" :key="index">
					<td>{{ rank.name }}</td>
					<td>{{ rank.step }}</td>
					<td><button type="button" class="btn btn-outline-success"  @click="editRank(rank)" data-toggle="modal" data-target="#editModal">Edit</button></td>
          <td><button type="button" class="btn btn-outline-danger" >Delete</button></td>
				</tr>
			</tbody>
		</table>
    <edit :rank="currentRank"></edit>
  </div>
</template>

<script>
import { mapState } from 'vuex';
import Add from './Add.vue'
import Edit from './Edit.vue';

export default {
  name: "settings",
  components: {
    Add,
    Edit
  },
  data() {
    return {
      currentRank: {}
    }
  },
  computed: {
    ...mapState([
      'showAdd',
      'ranks'
    ])
  },
  mounted() {
    this.$store.dispatch('populateRanks');
  },
  methods: {
    toggleAdd() {
      const toggle = !this.showAdd;
			this.$store.commit('toggleAdd', toggle);
    },
    editRank(edit) {
      this.currentRank = edit;
    }
  }
};
</script>