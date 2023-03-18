# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

![Arquitetura da Solução](img/02-mob-arch.png)

## Diagrama de Classes

Em programação, um diagrama de classes é uma representação da estrutura e relações das classes que servem de modelo para objetos. Podemos afirmar de maneira mais simples que seria um conjunto de objetos com as mesmas características, assim saberemos identificar objetos e agrupá-los, de forma a encontrar suas respectivas classes. 

> ![Diagrama de classes receita](https://user-images.githubusercontent.com/127369443/225708693-6f5aedea-cdd0-4f1c-b720-bc433821fed7.png)



## Modelo ER

O Esquema Relacional corresponde à representação dos dados em tabelas juntamente com as restrições de integridade e chave primária.

Na figura abaixo é mostrado o Esquema Relacional(ER).

![Modelo ER](img/modelo_er.png)

## Esquema Relacional

O Esquema Relacional corresponde à representação dos dados em tabelas juntamente com as restrições de integridade e chave primária.

Na figura abaixo é mostrado o Esquema Relacional(ER).

![Esquema Relacional](img/modelo_relacional.png)

## Modelo Físico

Os scripts da criação das tabelas do banco se encontram na pasta src\bd

[Direcionamento para o SQL](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e4-proj-infra-t1-time2-receita/blob/main/src/bd/FreecipeDB.sql)

## Tecnologias Utilizadas

Para o desenvolvimento, utilizaremos a mesma tecnologia utilizada pelo professor nas videoaulas, o Visual Studio 2022, para a hospedagem utilizaremos o GitHub.
Será utilizado  para o desenvolvimento web Back-end  o framework ASP.NET, com a linguagem de programação C#, para o desenvolvimento mobile usaremos o framework React Native do JavaScript.

Para o desenvolvimento do Front-end utilizaremos o HTML e css, para os diagramas utilizamos o diagrams.net, e para os templates utilizamos os Figma.

## Hospedagem

A hospedagem do nosso site e aplicativo será no Vercel, e o nosso Back-end será hospedado no banco de dados SQL do azure.


## Qualidade de Software

![image](https://user-images.githubusercontent.com/32153247/226087275-85fc5982-90f7-41eb-92f3-a37665b1a26f.png)
![image](https://user-images.githubusercontent.com/32153247/226087280-9f3ae5b4-ec9c-4f45-b122-346b278ece62.png)
![image](https://user-images.githubusercontent.com/32153247/226087286-02760a8d-41ee-4660-8781-9444dbf479e7.png)
![image](https://user-images.githubusercontent.com/32153247/226087290-35ecc29e-2ec0-4a52-bdca-5efd97ba475b.png)

Com base nessas características escolhemos algumas para focar no nosso projeto:

![image](https://user-images.githubusercontent.com/32153247/194778700-59d4ce4e-55b1-4dc3-a6e4-a28a66a52b9b.png)

> **Links Úteis**:
>
> - [ISO/IEC 25010:2011 - Systems and software engineering — Systems and software Quality Requirements and Evaluation (SQuaRE) — System and software quality models](https://www.iso.org/standard/35733.html/)
> - [Análise sobre a ISO 9126 – NBR 13596](https://www.tiespecialistas.com.br/analise-sobre-iso-9126-nbr-13596/)
> - [Qualidade de Software - Engenharia de Software 29](https://www.devmedia.com.br/qualidade-de-software-engenharia-de-software-29/18209/)
