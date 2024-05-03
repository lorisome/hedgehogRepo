<template>
  <div class="home">
   <h1 id="title">Spanish Practice - Ser and Estar Past and Present</h1>
   <div class="back-and-next" id="back">
    <button  class="nav-button">Back</button>
    </div>
    <div id="sentence-practice">
    <sentence-display v-for="sentence in this.$store.state.sentences" v-bind:key="sentence.id" v-bind:sentence="sentence" v-bind:activeSentenceId="activeSentenceId"/>
    </div>
    <div class="back-and-next" id="next">
    <button  class="nav-button">Next</button>
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
  },
  data(){
    return {
      activeSentenceId: 1
    }
  }
}
</script>
<style> 
.home{
  display: grid;
  grid-template-areas:"title title title"
    "back middle next";
  grid-template-rows: 1fr 7fr;
  grid-template-columns: 1fr 2fr 1fr;
}
#title{
  grid-area: title;
}
#back{
  grid-area: back;
}
#next{
  grid-area: next;
}
#sentence-practice{
    display: flex;
    flex-wrap: wrap;
    grid-area: middle;
      justify-self: center;
}
.nav-button{

  background-color:indigo;
  color: white;
  height: 6vh;
  width: 20vh;


}
.back-and-next{
    display: flex;
      flex-direction: column;
  justify-content: center;
  align-items: center;
}


</style>
