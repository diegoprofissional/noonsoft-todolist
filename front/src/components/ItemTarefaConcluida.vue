<template>
  <div class="container">
    <div class="bloco">
      <h2>{{ titulo }}</h2>

      {{ objetivo }}
    </div>

    <div class="blocoBotao">
      <div class="botao">
        <i style="color: #fff; cursor:pointer" @click="deletar" class="fa-solid fa-trash"></i>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import {urlBackend} from '../utils/configuracao.js'

export default {
  props: ["titulo", "objetivo", "id"],

  emits: ["deletar"],

  methods: {
    deletar() {
      axios.delete(`${urlBackend}/tarefas` + "/" + this.id).then(() => {
        this.$emit("atualizar-lista-tarefas");
      });
    },
  },
};
</script>

<style scoped>
.container {
  display: flex;
  flex-direction: row;
  background-color: #404040;
}

.bloco {
  flex: 9;
}

.blocoBotao {
  flex: 1;
}

button {
  background-color: #f0f;
}

h2 {
  color: #0eca76;
}
</style>