<template>
    <div class="nav">
      <h1>Instructor</h1>
    </div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: 'Instructor',
  data() {
    return {

    }
  },
  computed: {
    ...mapState([
      'instructor'
    ])
  }
};
</script>

<style>

</style>
