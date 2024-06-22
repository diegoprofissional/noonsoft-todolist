<template>
  <div class="containerFormulario">
    <FormularioNovaTarefa
      @atualizarListaTarefas="atualizarListaTarefas"
    ></FormularioNovaTarefa>

    <hr />

    <button
      @click="mudarBotaoSelecionado('inconcluidas')"
      :class="{ botao: true, botaoAtivo: botaoParaFazerAtivo }"
    >
      para fazer
    </button>
    <button
      @click="mudarBotaoSelecionado('concluidas')"
      :class="{ botao: true, botaoAtivo: botaoConcluidas }"
    >
      concluídas
    </button>
  </div>

  <div v-if="botaoParaFazerAtivo === true">
    <ItemTarefa
      @exibirModalEditar="exibirModalEditar"
      @atualizarListaTarefas="atualizarListaTarefas"
      v-for="tarefa in tarefas"
      :titulo="tarefa.titulo"
      :id="tarefa.id"
      :key="tarefa.id"
      :objetivo="tarefa.objetivo"
    ></ItemTarefa>
  </div>
  <div v-if="botaoConcluidas === true">
    <ItemTarefaConcluida
      @atualizarListaTarefasConcluidas="atualizarListaTarefasConcluidas"
      v-for="tarefa in tarefas"
      :titulo="tarefa.titulo"
      :id="tarefa.id"
      :key="tarefa.id"
      :objetivo="tarefa.objetivo"
    ></ItemTarefaConcluida>
  </div>

  <div v-if="modalAberta">
    <ModalFormularioEdicao
      @atualizarListaTarefas="atualizarListaTarefas"
      :id="id"
      :visible="modalAberta"
    ></ModalFormularioEdicao>
  </div>
</template>



<script>
import FormularioNovaTarefa from "./components/FormularioNovaTarefa.vue";
import ItemTarefa from "./components/ItemTarefa.vue";
import ItemTarefaConcluida from "./components/ItemTarefaConcluida.vue";
import ModalFormularioEdicao from "./components/ModalFormularioEdicao.vue";
import {urlBackend} from './utils/configuracao.js'

import axios from "axios";

export default {
  name: "App",
  components: {
    FormularioNovaTarefa,
    ItemTarefa,
    ItemTarefaConcluida,
    ModalFormularioEdicao,
  },
  data() {
    return {
      tarefas: [],
      botaoParaFazerAtivo: true,
      botaoConcluidas: false,
      modalAberta: false,
      id: 0,
    };
  },
  mounted() {
     axios.get(`${urlBackend}/tarefas`).then((resultado) => {
      this.tarefas = resultado.data;
    }).catch(() => {
    });
  },
  methods: {
    atualizarListaTarefas() {
      axios
        .get(`${urlBackend}/tarefas`)
        .then((resultado) => {
          this.tarefas = resultado.data;
          this.botaoParaFazerAtivo = true;
          this.botaoConcluidas = false;
        })
        .catch(() => {
          alert('Erro ao se conectar com o servidor!')
        });
    },
     atualizarListaTarefasConcluidas() {
      axios
        .get(`${urlBackend}/tarefas/concluidas`)
        .then((resultado) => {
          this.tarefas = resultado.data;
          
        })
        .catch(() => {
          alert('Erro ao se conectar com o servidor!')
        });
    },
    mudarBotaoSelecionado(botao) {
      if (botao == "concluidas") {
        this.botaoConcluidas = true;
        this.botaoParaFazerAtivo = false;
   
          axios
          .get(`${urlBackend}/tarefas/concluidas`)
          .then((resultado) => {
            this.tarefas = resultado.data;
          });
        
      } else {
        this.botaoConcluidas = false;
        this.botaoParaFazerAtivo = true;

         axios.get(`${urlBackend}/tarefas`).then((resultado) => {
      this.tarefas = resultado.data;
    }).catch(() => {
    });
      }
    },
    exibirModalEditar(data) {
      this.modalAberta = !this.modalAberta;
      this.id = data.id;
    },
  },
};




</script>

<style>
#app {
  margin: auto;
  max-width: 700px;
  background-color: #343434;
  padding: 20px;
}

.containerFormulario {
  margin: 10px;
}

body {
  background-color: #1e1e1e;
}

.botao {
  padding: 10px;
  border: 0px;
}

.botaoAtivo {
  background-color: #00e67d;
}
</style>
