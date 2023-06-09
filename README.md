# Lamp Puzzle

**Autoria:**

Tom�s Carvalho n� 22203333

- Escreveu o c�digo no `Main()` (incluindo o Main Loop) e o m�todo `DisplayLamps()`;
- Tratou da visualiza��o na consola das instru��es e do feedback do puzzle;
- Fez o fluxograma do funcionamento do c�digo;
- Definiu o sistema de Game Over (Win & Loss);

Jo�o Correia n� 22202506

- Implementou as fun��es `ButtonPress()` e `CheckWin()`;
- Tratou do funcionamento dos bot�es e das l�mpadas;
- Definiu a enumera��o LampStates;
- Escreveu a documenta��o README.md;




**Reposit�rio usado:**

https://github.com/ProfOakster/LP1_p1


**Arquiquetura da Solu��o:**

Este projeto atribui ao utilizador um certo n�mero de lampadas e bot�es, bem como um n�mero limitado de turnos. O objetivo � utilizar os bot�es e as suas funcionalidades para ligar todas as l�mpadas, um bot�o por turno, antes de ficar sem turnos.

O exerc�cio est� dividido em dois ficheiros:

1. **LampStates.cs**

    Cont�m a enumera��o LampStates, que define os valores de cada l�mpada usando shifts;

2. **Program.cs**

    Cont�m quatro m�todos:
    - `Main()`: Define as vari�veis a usar, como o n�mero de bot�es e turnos de jogo, e cont�m as instru��es de uso (mostradas na consola), bem como o Main Loop, que usa os restantes m�todos e repete-se at� o utilizador ficar sem turnos restantes;
    - `ButtonPress()`: Recebe o bot�o carregado e a vari�vel que cont�m o estado de todas as l�mpadas, e retorna a vari�vel atualizada ap�s o efeito do bot�o;
    - `CheckWin()`: Recebe a vari�vel com o estado das l�mpadas e verifica-as uma a uma. Se pelo menos uma estiver desligada, retorna `false`, mas em caso contr�rio, retorna `true`.
    - `DisplayLamps()`: Recebe a vari�vel com o estado das l�mpadas e o n�mero de l�mpadas, e mostra na consola a amarelo o estado de cada uma. L�mpadas acesas s�o representadas com um circulo cheio, e l�mpadas apagadas com um circulo vazio.

Abaixo encontra-se um fluxograma que representa o funcionamento do c�digo do in�cio ao fim:
![Fluxograma do c�digo](LampPuzzleDiagram.png)


**Refer�ncias:**

Foram usados como refer�ncia os PowerPoints disponibilizados pelo professor Nuno Fachada em LP1, bem como o exerc�cio "PlayerPerks", para a implementa��o e o funcionamento do m�todo `ButtonPress()`.