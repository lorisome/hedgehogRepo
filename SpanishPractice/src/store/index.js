import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    sentences: [
      {
        id: 0,
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
        id: 1,
        sentence: "You(formal) weren't in this place, I was.",
        verbASerOrEstar: "estar",
        verbAPastOrPresent: "past",
        verbAAnswer: "estaba",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "past",
        verbBAnswer: "estaba",
        fullTranslatedSentence: "Usted no estaba en this lugar, yo lo estaba."
      },
      {
        id: 2,
        sentence: "I'm a friend and they are with me.",
        verbASerOrEstar: "ser",
        verbAPastOrPresent: "present",
        verbAAnswer: "soy",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "present",
        verbBAnswer: "están",
        fullTranslatedSentence: "Soy una amiga y ellos estan conmigo."
      }, 
      {
        id: 3,
        sentence: "Were you the guy?",
        verbASerOrEstar: "ser",
        verbAPastOrPresent: "past",
        verbAAnswer: "eras",
        fullTranslatedSentence: "¿Eras tú el chico?"
      }
    ]
  },
  getters: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
  }
})
