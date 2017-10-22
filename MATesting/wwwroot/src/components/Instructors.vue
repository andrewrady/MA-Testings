<template>
  <div>
      <h2>Instructors</h2>
			<table class="table">
				<thead>
					<tr>
						<th scope="col">Id</th>
						<th scope="col">Name</th>
						<th scope="col">Rank</th>
					</tr>
				</thead>
				<tbody>
					<tr v-for="(instructor, index) in instructors" :key="index">
						<th scope="row">{{ instructor.id }}</th>
						<td>{{ instructor.name }}</td>
						<td>{{ instructor.rank }}</td>
					</tr>
				</tbody>
			</table>
  </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
  name: 'Instructor',
  computed: {
		...mapState([
				'instructors'
			])
	},
	mounted() {
		this.$store.dispatch('populateInstructor');
	}
}
</script>
