<template>
<div class="clickable-choice">
    <div class="ser-or-estar">
        <button v-bind:class="['ser',{'correct':this.serCorrect, 'incorrect':this.serIncorrect}]" v-on:click="determineSerCorrect($event)">Ser</button>
        <button v-bind:class="['estar',{'correct':this.estarCorrect, 'incorrect':this.estarIncorrect}]" v-on:click="determineEstarCorrect($event)">Estar</button>
        <div v-bind:class="['correct-identifier', {'hide':(!this.serCorrect && !this.estarCorrect)}]">Correct</div>
        <div v-bind:class="['incorrect-identifier',{'disappear':(!(this.serCorrect && this.estarCorrect) && !(this.serIncorrect || this.estarIncorrect))}]">Incorrect</div>
    </div>
    <div class="past-or-present">
        <button class="past" v-bind:class="['past',{'correct':this.pastCorrect, 'incorrect':this.pastIncorrect}]" v-on:click="determinePastCorrect($event)">Past</button>
        <button class="present" v-bind:class="['present',{'correct':this.presentCorrect, 'incorrect':this.presentIncorrect}]" v-on:click="determinePresentCorrect($event)">Present</button>
 <div v-bind:class="['correct-identifier', {'hide':(!this.pastCorrect && !this.presentCorrect)}]">Correct</div>
        <div v-bind:class="['incorrect-identifier',{'disappear':(!(this.pastCorrect && this.presentCorrect) && !(this.pastIncorrect || this.presentIncorrect))}]">Incorrect</div>
    </div>
    <div v-bind:class="{hide:(!this.serCorrect && !this.estarCorrect)||(!this.pastCorrect && !this.presentCorrect)}">Good Job, now select the correct conjugation!</div>
    <verb-choices v-show="(this.serCorrect || this.estarCorrect) &&(this.pastCorrect || this.presentCorrect)" v-bind:VerbAnswer="this.FinalVerbForm"/>
  </div>
</template>

<script>
import VerbChoices from './VerbChoices.vue';
export default {
props:['SerOrEstar', 'PastOrPresent', 'FinalVerbForm'],
components: {
    VerbChoices
},
data(){
    return{
        serCorrect: false,
        serIncorrect: false,
        estarCorrect: false,
        estarIncorrect: false,
        pastCorrect: false,
        pastIncorrect: false,
        presentCorrect: false,
        presentIncorrect: false
    }
},
methods:{
    determineSerCorrect(e){
        let correctButtonClicked = e.target.classList.contains(this.SerOrEstar);
        this.serCorrect = correctButtonClicked;
        if(this.serIncorrect){
        this.serIncorrect = false;
        }
        else{
            this.serIncorrect = !correctButtonClicked
        }
       
    },
    determineEstarCorrect(e){
        let correctButtonClicked = e.target.classList.contains(this.SerOrEstar);
        this.estarCorrect = correctButtonClicked;
        if(this.estarIncorrect){
        this.estarIncorrect = false;
        }
        else{
            this.estarIncorrect = !correctButtonClicked
        }
    },
    determinePastCorrect(e){
        let correctButtonClicked = e.target.classList.contains(this.PastOrPresent);
        this.pastCorrect = correctButtonClicked;
        if(this.pastIncorrect){
        this.pastIncorrect = false;
        }
        else{
            this.pastIncorrect = !correctButtonClicked
        }
    },
    determinePresentCorrect(e){
        let correctButtonClicked = e.target.classList.contains(this.PastOrPresent);
        this.presentCorrect = correctButtonClicked;
        if(this.presentIncorrect){
        this.presentIncorrect = false;
        }
        else{
            this.presentIncorrect = !correctButtonClicked
        }
    },
    turnIncorrectAndCorrectOff(){

    }
}
}
</script>

<style scoped>
div.clickable-choice{
    display: flex;
    flex-direction: column;
    justify-content:space-evenly;
    border: 2px solid #582a62;
    border-radius: 4px;
    margin: 5px;
    height: 30vh;
    background-color: rgb(239, 239, 239);
}
.ser-or-estar,
.past-or-present{
    display:flex;
    justify-content:space-evenly;
    gap: 5px;
    align-items: center;
    padding-bottom: 15px;
}
button {
  padding: 10px 20px;
  width: 85px;
  /* border: 1px solid #ddd;
  color: #333;
  background-color:#fff;
  border-radius: 4px;
  font-size: 14px; */
}


.hide{
    visibility:hidden;
}
.disappear{
    display:none;
}
.correct-identifier{
    color: darkgreen;
    font-weight:bold;
}
.incorrect-identifier{
    color: darkred;
    font-weight: bold;
}
</style>