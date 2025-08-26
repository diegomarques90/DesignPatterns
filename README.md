# Sobre o projeto DesignPatterns
O projeto foi criado durante a formação Arquitetura de Software do LuisDev.
O objetivo do projeto é trazer exemplos práticos da resolução de problemas comuns do desenvolvimento de software com a utilização de Design Patterns.

## Estrutura do projeto
No projeto, você encontrará exemplos práticos da utilização dos patterns para solucionar os problemas hipotéticos.
Logo, cada pattern possuirá um problema a ser resolvido, o qual estará descrito como comentário em cada controller principal e aqui no README.

# Estrutura do projeto
No projeto, você encontrará exemplos práticos da utilização dos patterns para solucionar os problemas hipotéticos.
Logo, cada pattern possuirá um problema a ser resolvido, o qual estará descrito como comentário em cada controller principal e aqui no README.

## O que são Design Patterns - Creational?
De forma bem resumida, são patterns que lidam com mecanismos de criação de instâncias de objetos.
O objetivo é melhorar a maneira de criação de instâncias, reduzindo a complexidade envolvida.
Vale salientar que, os problemas é quem guiam a escolha do pattern e nunca o contrário.

## Design Pattern - Creational: Factory Method
** Problema hipotético:**
Dado que uma startup com e-commerce precisa processar seus pagamentos ao receber pedidos.
Dependendo da forma de pagamento o direcionamento do processamento será distinto e atualmente as formas de pagamento são: Cartão de Crédito ou boleto, porém, chegou a solicitação para implementar a forma de pagamento PIX.
No exemplo de controller sem a correção, o código é complexo e crescendo a cada nova implementação de forma de pagamento.

**O que foi feito para resolver o problema hipotético?**
Criamos a classe IPaymentServiceFactory contendo o contrato do método GetService que retorna a interface IPaymentService.
Na implementação da classe IPaymentServiceFactory, injetamos os serviços de CreditCardService e PaymentSlipService e de acordo com o tipo da forma de pagamento, retornaremos o serviço correspondente.
Os dois serviços (CreditCard e PaymentSlip) possuem sua própria interface (IPaymentService) e suas próprias implementações do método Process.

## Design Pattern - Creational: Abstract Factory
**Problema Hipotético:**
Dado que uma Startup de E-Commerce, possui a necessidade de implementar a restrinção do pagamento e envio dependendo da origem da compra (internacional ou local).
Condicional origem:
	* Internacional: O pagamento deverá ser realizado apenas por cartão de crédito;
	* Local: O pagamento poderá ser feito por cartão de crédito, débito ou boleto;
Cada condicional possuirá maneiras distintas para processar o envio.
A ideia consiste em implementar o Abstract Factory para realizar a implementação e instanciação de um conjunto de objetos, que neste problema são:
	* Objeto do Serviço de Pagamentos;
	* Objeto do Serviço de Envio;

**O que foi feito para resolver o problema hipotético?**
Criamos a classe IOrderAbstractFactory contendo o contrato para dois métodos que retornarão os serviços de pagamento e de entrega (IPaymentService e IDeliveryService).
Cada serviço que será retornado, possui sua própria interface e implementações separadas, fazendo com que o cliente não possua acesso a implementação.
Nesta solução estamos utilizando o Abstract Factory para retornar o conjunto de objetos (PaymentService e DeliveryService) e para cada service, temos a implementação do Factory Method.

## Design Pattern - Creational: Builder
**Problema Hipotético:**
Dado o fato que a Startup de E-Commerce possui a necessidade da geração de boletos e que cada boleto possuíra suas próprias características, sendo:
* Nosso número, 
* código do cedente, 
* cedente, 
* pagador, 
* data de vencimento, 
* data de emissão e entre outras;
A construção deste objeto Boleto, possui bastantes condicionais e variações, portanto, o ideal é utilizarmos o padrão builder para organizar a construção do objeto por etapas.
		
**O que foi feito para resolver o problema hipotético?**
Criamos a classe PaymentSlipBuilder e implementamos o padrão builder, criando os métodos que farão o preenchimento das informações por etapas.
Em seguida, instanciamos a classe PaymentSlipBuilder no serviço de geração dos boletos e contruímos o objeto de boleto de acordo com a necessidade, chamando as etapas.

## Design Pattern - Creational: Prototype
**Problema Hipotético:**
Dado o fato que a Startup de E-Commerce possui a necessidade de gerar um novo pedido à partir de um outro pedido já realizado anteriormente.

**O que foi feito para resolver o problema hipotético?**
	Criamos a rota CloneOrderById, a qual, recebe o id do pedido que deverá ser clonado, como o projeto é voltado para a implementação de exemplos dos patterns, por isso, não temos a real implementação de um serviço para fazer a busca por id, fiz a implementação do padrão builder para a criação do objeto OrderInputModel.
	Utilizo o OrderBuilder para criar um objeto OrderInputModel para poder realizar o clone do objeto chamando o método Clone.
	Não fiz a implementação da Interface na mão, pois, no c# já temos a disponibilização da interface ICloneable, portanto, para implementar o padrão builder, apenas incluí a herança da interface ICloneable na classe OrderInputModel e implementei a clonagem do objeto no método Clone.

## Design Pattern - Creational: Singleton
**Problema Hipotético:**
Dado que a startup de E-Commerce precise de uma rota para retornar um objeto que possua o horário de funcionamento.

**O que foi feito para resolver o problema hipotético?**
Criamos a classe BusinessHour para armazenar os dados com o horário de funcionamento, também criamos a rota para obter o objeto BusinessHour.
Na classe BusinessHour, implementamos o construtor privado e o método GetInstance() para criar o algoritmo que faz a instanciação da classe no padrão singleton, garantindo um ponto de acesso único global e também que apenas uma instância da classe esteja disponível para a aplicação.	

## O que são Design Patterns - Structural?
Os padrões estruturais se preocupam com a forma como as classes e objetos são compostos para formar estruturas maiores mas ainda mantendo essas estruturas flexíveis e eficientes. 
Estes padrões estruturais de classes utilizam a herança para compor interfaces ou implementações.

## Design Pattern - Structural: Adapter
**Problema Hipotético:**
Dado que o serviço de geração de boletos interno passará a receber os dados do boleto de forma externa e o objeto com os dados do boleto não será enviado no formato esperado para a geração interna do boleto.

**O que foi feito para resolver o problema hipotético?**
Para solucionar esse problema, foi aplicado o Adapter para fazer a conversão e tratamento dos dados externos para o PaymentSlipService realizar o processamento do boleto.o padrão singleton, garantindo um ponto de acesso único global e também que apenas uma instância da classe esteja disponível para a aplicação.	

## Design Pattern - Structural: Decorator
**Problema Hipotético:**
Dado que o e-commerce precise enviar uma notificação para um software CRM a cada pedido processado contendo os dados da compra, precisaremos implementar o envio sem alterar as implementações de IPaymentService para realizar a chamada.

**O que foi feito para resolver o problema hipotético?**
Imaginando o cenário em que a sincronização com o CRM possua uma interface própria, incluímos a interface ICoreCrmIntegrationService que possui o contrato do método Sync. Criamos a rota processOrderWithSyncToCrm na OrdersController para separar do fluxo padrão as orders que farão o envio para o CRM.
Implementamos o decorator PaymentServiceDecorator, o qual herda a interface que vamos extender IPaymentService e na implementação do método Process, fazemos o envio da sincronização com o método Sync do service ICoreCrmIntegrationService, deste modo, conseguimos extender o método Process sem alterar a sua implementação original.

## Design Pattern - Structural: Facade
**Problema Hipotético:**
Dado que o e-commerce precise fazer uma requisição http em uma rota terceira para verificar fraude antes do processamento. O processo para fazer essa requisição é complexo pela quantidade de objetos que precisam ser instanciados e configurados. Como tornar o processo mais simples nas classes clientes?

**O que foi feito para resolver o problema hipotético?**
Para resolver esse problema hipotético, fizemos a implementação do design pattern structural facade, onde criamos a interface IAntiFraudFacade, a qual possui apenas a assinatura do método Check.
Levamos para a implementação da interface todo o algorítimo que de fato faz a requisição e retorna o objeto desejado, deste modo, a classe cliente apenas instância a interface e faz a chamada simplificada do método Check;

## Design Pattern - Structural: Proxy
**Problema Hipotético:**
Dado que o e-commerce precise controlar o acesso a lista de clientes bloqueados que é obtida por um repositório e armazenada em um cache. Se implementarmos o controle e cache em cada objeto cliente, vamos gerar códigos duplicados e entre outros problemas.

**O que foi feito para resolver o problema hipotético?**
Para resolver esse problema hipotético, fizemos a implementação do design pattern structural Proxy, onde criamos a classe CustomerRepositoryProxy, a qual herda a interface do objeto original ICustomerRepository.
Na classe CustomerRepositoryProxy, implementamos o método do contrato GetBlockedCustomers e fizemos o controle do acesso e controle de cache antes da utilização do repository para obter os clientes bloqueados, deste modo, as classes clientes tem que apenas utilizar a instância do objeto Proxy;

## Design Pattern - Structural: Composite
**Problema Hipotético:**
Dado que você precisa calcular o valor de gastos corporativos em uma estrutura de hierarquia de cargos e funções.

**O que foi feito para resolver o problema hipotético?**
Para resolver esse problema hipotético, fizemos a implementação do pattern Composite.
Iniciamos com a implementação da classe abstrata EmployeeComponent que possui as propriedades e métodos comuns da composição. 
Em seguida implementamos as classes Employee (Leaf) e ManagerComposite (Composite).A classe Employee possui apenas a implementação do método abstrato que retorna o valor do gasto corporativo. Já a classe ManagerComposite, além de implementar o método abstrato para o cálculo do gasto corporativo, controla a inclusão ou remoção dos filhos.
Para finalizar, o uso desta estrutura é realizado na EmployeesController.

## Design Pattern - Structural: Bridge
**Problema Hipotético:**
Dado que você precisa retornar o content de páginas web de acordo com o tema e que não precisa para cada tema novo crescer a implementação de forma exponencial.
	
**O que foi feito para resolver o problema hipotético?**
Implementamos o pattern Brigde, onde na prática criamos duas interfaces uma para o tema e a outra para as páginas. A utilização das mesmas foi criada na controller PageThemesController. 

## Design Pattern - Structural: Flyweight
**Problema Hipotético:**
Dado que na aplicação seja necessário retornar um objeto que contém dados a respeito de formas de pagamento de um pedido.
	
**O que foi feito para resolver o problema hipotético?**
Implementamos o pattern Flyweight, onde na prática criamos a interface da fábrica (IPaymentMethodsFactory) e também fizemos a implementação concreta da fábrica (PaymentMethodsFactory). A fábrica é classe responsável por gerenciar as formas de pagamento via Dictionary.
Na controller PaymentMethodsController, foram implementadas duas rotas GET, uma sem a implamentação do pattern e a outra com a implementação do pattern.
Também utilizamos o escopo singleton para deixar a fábrica em uma única instância.

## O que são Design Patterns - Behavioral?
São design patterns que lidam com a comunicação e comportamento de uma classe em relação a outra. Eles não descrevem apenas padrões de objetos ou classes, mas também os padrões de comunicação entre eles.

## Design Pattern - Behavioral: Chain of Responsibility (CoR)
**Problema Hipotético:**
Imagina um e-comerce que ao receber um pedido deve-se validar:
* Os itens do pedido possuem estoque?
* O cliente está com o cadastro em dia e com permissão para fazer pedidos?
* O pedido é uma fraude?
Deste modo, existem várias etapas de verificação que podem fazer com o que o pedido não seja aprovado e na medida em que novas validações sejam incluídas ou novas etapas, o código poderá crescer de forma desorganizada e aumentar a complexidade.
	
**O que foi feito para resolver o problema hipotético?**
Implementamos o pattern CoR, onde na prática criamos a interface IOrderHandler que possui apenas dois métodos no contrato, sendo:	
* bool Handle(): Responsável pela implementação da regra de negócio; e
* IOrderHandler SetNext(IOrderHandler nextHandler), responsável pela definição do próximo handler da corrente;
As mecânicas desta interface foram implementadas em uma classe base abstrata (OrderHandlerBase), deste modo, as implementações concretas de cada elo da corrente puderam fazer a sobreposição do método Handle e aplicar a sua própria validação.
As implementações concretas foram:
* ValidateStockHandler;
* ValidateCustomerHandler;
* ValidateForFraudHandler;
A classe cliente deste pattern é a OrdersController, onde disponibilizei uma rota com o exemplo sem o pattern ("not-using-chain) e outra rota com o exemplo utilizando o pattern ("using-chain").

## Design Pattern - Behavioral: Command
**Problema Hipotético:**
Imagina o cenário em que o e-commerce ao receber um pedido seja necessário verificar se é uma fraude e os parâmetros de entrada devem ser armazenados em um serviço de LOG ou serem enviados para uma fila de mensageria.
Uma das soluções simples para encapsular os parâmetros de entrada é a criação de um objeto anônimo, mas neste caso correria o risco de ter duplicação de código. 
Podemos utilizar o padrão Command para resolver esse problema.
		
**O que foi feito para resolver o problema hipotético?**
Implementamos a rota POST PostUsingCommand na OrdersController, que basicamente substitui a criação de um objeto genérico para um objeto do tipo FraudCheckModel. 
Também implementamos o método IsFraudV2UsingCommand, o qual recebe como parâmetro de entrada o objeto FraudCheckModel e ao utilizar esse método para verificar se é uma fraude, já temos o objeto FraudCheckModel instanciado na variável command.
Após a verificação da fraude não precisaremos criar objetos genéricos, pois, já temos o objeto instanciado pela variável command e isso facilitará o repasse do objeto para outros serviços ou métodos, como por exemplo:
*Serviços de mensaria; e
*Guarda de logs.

## Desing Pattern - Behavioral: Iterator
**Problema Hipotético:**
Imagine que no e-commerce precisaremos percorrer uma lista de clientes bloqueados e realizar certa ação, como por exemplo notificá-los por e-mail. Porém, para isso, não podemos expor a estrutura interna de um modelo que já estamos utilizando.
No exemplo, estamos utilizando um dicionário para armazenar os clientes e seus e-mails.

**O que foi feito para resolver o problema hipotético?**
Implementamos a rota "report-notify-blocked-customers" na CustomersController, onde instanciamos uma nova coleção de dados (Dictionary<string, string>), a qual armazenamos o FullName e o Email do customer.
Note que não é a classe cliente (CustomersController) que é responsável por criar a coleção ou saber detalhes da implementação de como a coleção é iterada. A criação e iteração da coleção é realizada pela classe CustomersToNotifyQueryModel.
Já no construtor, recebemos a lista de customers e uma string para informar quem criou a coleção. Para fazer as iterações extendemos a classe com a implementação da Interface IEnumerable<KeyValuePair<string, string>>.
Em resumo, a classe cliente consegue instanciar a coleção e utilizá-la percorrendo-a (foreach) ou acessando o item da coleção diretamente e tudo isso sem saber os detalhes da implementação de como a coleção é criada e iterada.

## Desing Pattern - Behavioral: Mediator
**Problema Hipotético:**
Imagine que estamos desenvolvendo controllers utilizando a arquitetura CQRS e neste caso, cada controller precisará saber quais queries e handlers instanciar gerando comunicações diretas.
Na medida que mais controllers forem criadas o código se tornará repetitivo em sua estrutura, para melhorar esse cenário é possível implementar o pattern Mediator.

**O que foi feito para resolver o problema hipotético?**
Implementamos o patter Mediator através da interface ICqrsMediator e deixamos o exemplo de utilização pela ProductsController, a qual, possui os exemplos para obter produtos e obter produto por id com e sem o pattern Mediator.

## Observações Gerais
Os códigos implementados não possuem a injeção de dependência correta nos padrões do .NET 8, o intuíto do projeto é mostrar a implementação dos Design Patterns de forma mais simplificada e objetiva.

## Fontes
* **Curso:** Formação arquitetura de software - LuisDev.
* **Livro:** Padrões de projeto - Soluções reutilizáveis de software orientado a objetos;
* **Artigos:** Refactoring Guru - https://refactoring.guru/pt-br/design-patterns
* **Repositórios:** https://github.com/design-patterns-for-humans/brazilian-portuguese
