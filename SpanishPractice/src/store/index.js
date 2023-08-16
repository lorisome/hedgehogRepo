import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
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
