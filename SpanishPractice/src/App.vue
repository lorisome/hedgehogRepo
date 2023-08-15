<template>
  <div id="app">
    <h1>Spanish Practice - Ser and Estar Past and Present</h1>
    <div id="sentence-practice">
    <sentence-display v-for="sentence in sentences" v-bind:key="sentence.index" v-bind:sentence="sentence" />
    </div>
  </div>
</template>

<script>
import SentenceDisplay from './components/SentenceDisplay.vue'

export default {
  name: 'app',
  components: {
    SentenceDisplay
  },
  data() {
    return{
    sentences: [
      {
        sentence: "She wasn't a friend, I was.",
        verbASerOrEstar: "ser",
        verbAPastOrPresent: "past",
        verbAAnswer: "era",
        verbBSerOrEstar: "ser",
        verbBPastOrPresent: "past",
        verbBAnswer: "era", 
        fullTranslatedSentence: "Ella no era una amiga, yo lo era."
        }, 
      {
        sentence: "You(formal) weren't in this place, I was.",
        verbASerOrEstar: "estar",
        verbAPastOrPresent: "past",
        verbAAnswer: "estaba",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "past",
        verbBAnswer: "estaba",
        fullTranslatedSentence: "Usted no estaba en this lugar, yo lo estaba."
      },
      {sentence: "I'm a friend and they are with me.",
        verbASerOrEstar: "ser",
        verbAPastOrPresent: "present",
        verbAAnswer: "soy",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "present",
        verbBAnswer: "estan",
        fullTranslatedSentence: "Soy una amiga y ellos estan conmigo."
      }, 
      {
        sentence: "Were you the guy?",
        verbASerOrEstar: "ser",
        verbAPastOrPresent: "past",
        verbAAnswer: "soy",
        fullTranslatedSentence: "¿Eras tú el chico?"
      }
    ]
    }
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin: 60px;
}
#sentence-practice{
    display: flex;
    flex-wrap: wrap;
}
</style>
