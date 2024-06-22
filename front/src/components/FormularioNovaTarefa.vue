<template>
  <form @submit.prevent="">
    <div class="container">
      <div class="bloco">
        <div><label>titulo:</label></div>
        <input style="margin-bottom:5px;" v-model="titulo" />
      </div>

      <div class="bloco">
        <div><label>objetivo:</label></div>
        <input style="margin-bottom:5px;" v-model="objetivo" />
      </div>

      <div class="bloco">
        <button @click="adicionarTarefa">adicionar</button>
      </div>
    </div>
  </form>
</template>


<script>
import axios from "axios";
import { urlBackend } from "../utils/configuracao.js";

export default {
  data() {
    return {
      titulo: "",
      objetivo: "",
    };
  },

  emits: ["atualizar-lista-tarefas"],
  methods: {
    adicionarTarefa() {

    if(this.titulo == '' || this.objetivo == ''){
        alert("Por favor, preencha todos os dados.")
        return;
    }

      let data = {
        titulo: this.titulo,
        objetivo: this.objetivo,
      };

      axios
        .post(`${urlBackend}/tarefas`, data)
        .then(() => {
          this.$emit("atualizar-lista-tarefas");
          this.titulo = '';
          this.objetivo = ''
        })
        .catch(() => {
          alert("Por favor preencha todos os campos");
        });
    },
  },
};
</script>

<style scoped>
.container {
  display: flex;
  flex-direction: row;
  margin-bottom: 10px;
}

.bloco {
  display: flex;
  flex-direction: column;
  justify-content: center; 
  flex: 1;
  margin-right: 10px; 
}
button {
  background-color: #00e67d;
  padding: 10px;
  border: 0px;
}

label {
  color: #fff;
  font-weight: bold;
}
</style>