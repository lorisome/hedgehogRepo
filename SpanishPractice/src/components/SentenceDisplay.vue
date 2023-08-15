<template>
<div class="sentence-display">
  <h2 class="sentence">{{sentence.sentence}}</h2>
  <clickable-choices v-bind:SerOrEstar="sentence.verbASerOrEstar" v-bind:PastOrPresent="sentence.verbAPastOrPresent" v-bind:FinalVerbForm="sentence.verbAAnswer"/>
  <clickable-choices v-if="sentence.verbBSerOrEstar" v-bind:SerOrEstar="sentence.verbBSerOrEstar" v-bind:PastOrPresent="sentence.verbBPastOrPresent" v-bind:FinalVerbForm="sentence.verbBAnswer"/>
  <button class="answer-button" v-on:click.prevent="toggleShowAnswer()">Show/Hide Answer</button>
  <h2 class="answer" v-show="shouldShowAnswer">{{sentence.fullTranslatedSentence}}</h2>
  </div>
</template>

<script>
import ClickableChoices from './ClickableChoices.vue';
export default {
props: ['sentence'],
components:{
  ClickableChoices   
},
data(){
  return{
    shouldShowAnswer: false
  }
},
methods: {
  toggleShowAnswer(){
    this.shouldShowAnswer = !this.shouldShowAnswer;
  }

}
}
</script>

<style>
.sentence-display{
  border: 2px solid black;
  border-radius: 10px;
  width: 450px;
  height: 450px;
  margin: 20px;
  background-color:rgb(253, 212, 218);
}
h2{
  padding-left: 1vw;
  padding-right: 1vw;
}
.answer-button{
  margin-top:10px;
}
</style>