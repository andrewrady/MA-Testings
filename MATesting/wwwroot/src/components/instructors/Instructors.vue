<template>
  <div>
		<br>
		<div class="row">
			<div class="col">
				<h2>Instructors</h2>
			</div>
			<div class="col">
				<button type="button" class="btn btn-outline-primary float-right" @click="toggleAdd" v-if="!showAdd">Add</button>
				<button type="button" class="btn btn-outline-danger float-right" @click="toggleAdd" v-if="showAdd">Close</button>
			</div>
		</div>
		<add v-if="showAdd" :showAdd="showAdd"></add>
		<table class="table border">
			<thead>
				<tr>
					<th scope="col">Id</th>
					<th scope="col">Name</th>
					<th scope="col">Rank</th>
					<th scope="col">Delete</th>
					<td scope="col">Edit</td>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(instructor, index) in instructors" :key="index">
					<th scope="row">{{ instructor.id }}</th>
					<td>{{ instructor.name }}</td>
					<td>{{ instructor.rank }}</td>
					<td><button type="button" class="btn btn-outline-danger" @click="deleteInstructor(instructor.id)">Delete</button></td>
					<td><button type="button" class="btn btn-outline-success" @click="editInstructor(instructor)" data-toggle="modal" data-target="#editModal">Edit</button></td>
				</tr>
			</tbody>
		</table>
		<edit :instructor="currentInstructor"></edit>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import Add from './Add.vue'
import Edit from './Edit.vue';

export default {
	name: 'Instructor',
	components: {
		Add,
		Edit
	},
	data() {
		return {
			showEdit: false,
			currentInstructor: {}
		}
	},
  computed: {
		...mapState([
				'instructors',
				'showAdd'
			])
	},
	watch: {
		removeAdd(e) {
			console.log(e)
			this.showAdd = false;
		}
	},
	mounted() {
		this.$store.dispatch('populateInstructor');
	},
	methods: {
		toggleAdd() {
			const toggle = !this.showAdd;
			this.$store.commit('toggleAdd', toggle);
		},
		editInstructor(edit) {
			this.currentInstructor = edit;
		},
		deleteInstructor(id) {
			this.$store.dispatch('deleteInstructor', id);
		},
	}
}
</script>
