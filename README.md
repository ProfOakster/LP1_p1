# Lamp Puzzle

**Autoria:**

Tomás Carvalho nº 22203333

- Escreveu o código no `Main()` (incluindo o Main Loop);
- Implementou a visualisação na consola das instruções e outros feedbacks do puzzle;
- Definiu o sistema de Game Over (Win & Loss);

João Correia nº 22202506

- Implementou as funções a usar no Main Loop ( `ButtonPress()` e `CheckWin()` )
- Definiu a enumeração LampStates;
- Escreveu a documentação README.md;




**Repositório usado:**

https://github.com/ProfOakster/LP1_p1


**Arquiquetura da Solução:**

Este projeto atribui ao utilizador um certo número de lampadas e botões, bem como um número limitado de turnos. O objetivo é utilizar os botões e as suas funcionalidades para ligar todas as lâmpadas, um botão por turno, antes de ficar sem turnos.

O exercício está dividido em dois ficheiros:

1. LampStates.cs

Contém a enumeração LampStates, que define os valores de cada lâmpada usando shifts;

2. Program.cs

Contém três métodos:
    - `Main()`: Define as variáveis a usar, como o número de botões e turnos de jogo, e contém as instruções de uso (mostradas na consola), bem como o Main Loop, que usa os restantes métodos e repete-se até o utilizador ficar sem turnos restantes;
    - `ButtonPress()`: Recebe o botão carregado e a variável que contém o estado de todas as lâmpadas, e retorna a variável atualizada após o efeito do botão;
    - `CheckWin()`: Recebe a variável com o estado das lâmpadas e verifica-as uma a uma. Se pelo menos uma estiver desligada, retorna `false`, mas em caso contrário, retorna `true`.

Abaixo encontra-se um fluxograma que representa o funcionamento do código do início ao fim:
![Fluxograma do código](PLACEHOLDER.jpg)


**Referências:**

Foram usados como referência os PowerPoints disponibilizados pelo professor Nuno Fachada em LP1, bem como o exercício "PlayerPerks", para a implementação e o funcionamento do método `ButtonPress()`.