# Projeto RequisicaoCEP

É um projeto para atender o Tech Challenge da Fase 3 da Pós-Graduação em Arquitetura de Sistemas .Net com Azure - FIAP

O tema foi inspirado no projeto desenvolvido na Fase 1 pelo Mateus Pereira:
https://github.com/mateusrpereira/ApiLocaliza-POSTECH

Tratam-se de dois microsserviços:
- O primeiro é uma API (produtor) com um endpoint que recebe os dados para solicitação de um novo CEP e os envia como mensagem para uma fila;
- O segundo é um Serviço (consumidor) que consome as mensagens da fila, recuperando as informações e gravando em uma base de dados.

Para ser aderente à proposta do curso, foi escolhido o Azure Service Bus como Message Broker (fila).

Além dos requisitos solicitados no projeto, foram utilizados outros recursos da plataforma Azure da Microsoft apresentados, principalmente nessa, mas também durante fases anteriores do curso, tais como:
- App Configuration
- SQL Database
- Key Vaults
- Application Insights

A solução foi desenvolvida utilizando a linguagem C# na versão 8.0 do .NET framework.

No arquivo Resources_Azure.txt estão disponíveis as instruções para criação dos recursos, na plataforma Azure, utilizados pelo projeto.