<template>
  <div>
    <br>
		<div class="row">
			<div class="col">
				<h2>Students</h2>
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
					<th scope="col">Id</th>
					<th scope="col">Name</th>
					<th scope="col">Rank</th>
          <th scope="col">Size</th>
					<th scope="col">Delete</th>
					<td scope="col">Edit</td>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(student, index) in students" :key="index">
					<th scope="row">{{ student.id }}</th>
					<td>{{ student.name }}</td>
					<td>{{ student.rank }}</td>
          <td>{{ student.size }}</td>
					<td><button type="button" class="btn btn-outline-danger" @click="deleteStudent(student.id)">Delete</button></td>
					<td><button type="button" class="btn btn-outline-success" @click="editStudent(student)"  data-toggle="modal" data-target="#editModal">Edit</button></td>
				</tr>
			</tbody>
		</table>
    <edit :student="currentStudent"></edit>
  </div>
</template>

<script>
import { mapState } from 'vuex';
import Add from './Add.vue';
import Edit from './Edit.vue';

export default {
  name: 'student-component',
  components: {
    Add,
    Edit
  },
  data() {
    return {
      showEdit: false,
      currentStudent: {}
    }
  },
  computed: {
    ...mapState([
      'students',
      'showAdd'
    ])
  },
  mounted() {
    this.$store.dispatch('populateStudents')
  },
  methods: {
    toggleAdd() {
			const toggle = !this.showAdd;
			this.$store.commit('toggleAdd', toggle);
    },
    editStudent(student) {
      this.currentStudent = student
    },
    deleteStudent(id) {
      this.$store.dispatch('deleteStudent', id);
    }
  }
}
</script>
