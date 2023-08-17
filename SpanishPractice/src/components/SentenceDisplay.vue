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
  height: auto;
  margin: 20px;
  background-color:rgb(223, 198, 248);
}
h2{
  padding-left: 1vw;
  padding-right: 1vw;
}
.answer-button{
  margin-top:10px;
}
button{
  border: 1px solid #ddd;
  color: #333;
  background-color:#fff;
  border-radius: 4px;
  font-size: 14px;
}
.correct{
    background-color:rgb(75, 211, 75)
}
.incorrect{
    background-color:rgb(238, 67, 67)
}
</style>