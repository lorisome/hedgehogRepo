<template>
  <div class="home">
   <h1>Spanish Practice - Ser and Estar Past and Present</h1>
   
    <div id="sentence-practice">
    <sentence-display v-for="sentence in this.$store.state.sentences" v-bind:key="sentence.index" v-bind:sentence="sentence" />
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import SentenceDisplay from '../components/SentenceDisplay.vue'

export default {
  name: 'HomeView',
  components: {
    SentenceDisplay
  }
}
</script>
<style> 
#sentence-practice{
    display: flex;
    flex-wrap: wrap;
}

</style>
