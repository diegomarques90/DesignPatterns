# Sobre o projeto DesignPatterns
O projeto foi criado durante a formação Arquitetura de Software do LuisDev.
O objetivo do projeto é trazer exemplos práticos da resolução de problemas comuns do desenvolvimento de software com a utilização de Design Patterns.

# O que são Design Patterns - Creational?
De forma bem resumida, são patterns que lidam com mecanismos de criação de instâncias de objetos.
O objetivo é melhorar a maneira de criação de instâncias, reduzindo a complexidade envolvida.
Vale salientar que, os problemas é quem guiam a escolha do pattern e nunca o contrário.

# Estrutura do projeto
No projeto, você encontrará exemplos práticos da utilização dos patterns para solucionar os problemas hipotéticos.
Logo, cada pattern possuirá um problema a ser resolvido, o qual estará descrito como comentário em cada controller principal e aqui no README.

# Design Pattern - Creational: Factory Method
Problema hipotético:
	Dado que uma startup com e-commerce precisa processar seus pagamentos ao receber pedidos.
Dependendo da forma de pagamento o direcionamento do processamento será distinto e atualmente as formas de pagamento são: Cartão de Crédito ou boleto, porém, chegou a solicitação para implementar a forma de pagamento PIX.
No exemplo de controller sem a correção, o código é complexo e crescendo a cada nova implementação de forma de pagamento.

O que foi feito para resolver o problema hipotético?
Criamos a classe IPaymentServiceFactory contendo o contrato do método GetService que retorna a interface IPaymentService.
Na implementação da classe IPaymentServiceFactory, injetamos os serviços de CreditCardService e PaymentSlipService e de acordo com o tipo da forma de pagamento, retornaremos o serviço correspondente.
Os dois serviços (CreditCard e PaymentSlip) possuem sua própria interface (IPaymentService) e suas próprias implementações do método Process.

# Design Pattern - Creational: Abstract Factory
Problema Hipotético:
	Dado que uma Startup de E-Commerce, possui a necessidade de implementar a restrinção do pagamento e envio dependendo da origem da compra (internacional ou local).
Condicional origem:
	Internacional: O pagamento deverá ser realizado apenas por cartão de crédito;
	Local: O pagamento poderá ser feito por cartão de crédito, débito ou boleto;
Cada condicional possuirá maneiras distintas para processar o envio.

A ideia consiste em implementar o Abstract Factory para realizar a implementação e instânciação de um conjunto de objetos, que neste problema são:
	Objeto do Serviço de Pagamentos;
	Objeto do Serviço de Envio;

O que foi feito para resolver o problema hipotético?
Criamos a classe IOrderAbstractFactory contendo o contrato para dois métodos que retornarão os serviços de pagamento e de entrega (IPaymentService e IDeliveryService).
Cada serviço que será retornado, possui sua própria interface e implementações separadas, fazendo com que o cliente não possua acesso a implementação.
Nesta solução estamos utilizando o Abstract Factory para retornar o conjunto de objetos (PaymentService e DeliveryService) e para cada service, temos a implementação do Factory Method.

# Design Pattern - Creational: Builder
Problema Hipotético:
	Dado o fato que a Startup de E-Commerce possui a necessidade da geração de boletos e que cada boleto possuíra suas próprias características, sendo:
		Nosso número, código do cedente, cedente, pagador, data de vencimento, data de emissão e entre outras;
	A construção deste objeto Boleto, possui bastantes condicionais e variações, portanto, o ideal é utilizarmos o padrão builder para organizar a construção do objeto por etapas.
		
O que foi feito para resolver o problema hipotético?
	Criamos a classe PaymentSlipBuilder e implementamos o padrão builder, criando os métodos que farão o preenchimento das informações por etapas.
	Em seguida, instânciamos a classe PaymentSlipBuilder no serviço de geração dos boletos e contruímos o objeto de boleto de acordo com a necessidade, chamando as etapas.

# Design Pattern - Creational: Prototype
Problema Hipotético:
	Dado o fato que a Startup de E-Commerce possui a necessidade de gerar um novo pedido à partir de um outro pedido já realizado anteriormente.

O que foi feito para resolver o problema hipotético?
	Criamos a rota CloneOrderById, a qual, recebe o id do pedido que deverá ser clonado, como o projeto é voltado para a implementação de exemplos dos patterns, por isso, não temos a real implementação de um serviço para fazer a busca por id, fiz a implementação do padrão builder para a criação do objeto OrderInputModel.
	Utilizo o OrderBuilder para criar um objeto OrderInputModel para poder realizar o clone do objeto chamando o método Clone.
	Não fiz a implementação da Interface na mão, pois, no c# já temos a disponibilização da interface ICloneable, portanto, para implementar o padrão builder, apenas incluí a herança da interface ICloneable na classe OrderInputModel e implementei a clonagem do objeto no método Clone.

# Design Pattern - Creational: Singleton
Problema Hipotético:
	Dado que a startup de E-Commerce precise de uma rota para retornar um objeto que possua o horário de funcionamento.

O que foi feito para resolver o problema hipotético?
	Criamos a classe BusinessHour para armazenar os dados com o horário de funcionamento, também criamos a rota para obter o objeto BusinessHour.
	Na classe BusinessHour, implementamos o construtor privado e o método GetInstance() para criar o algoritmo que faz a instanciação da classe no padrão singleton, garantindo um ponto de acesso único global e também que apenas uma instância da classe esteja disponível para a aplicação.	

# O que são Design Patterns - Structural?
Os padrões estruturais se preocupam com a forma como as classes e objetos são compostos para formar estruturas maiores mas ainda mantendo essas estruturas flexíveis e eficientes. 
Estes padrões estruturais de classes utilizam a herança para compor interfaces ou implementações.

# Design Pattern - Structural: Adapter
Problema Hipotético:
	Dado que o serviço de geração de boletos interno passará a receber os dados do boleto de forma externa e o objeto com os dados do boleto não será enviado no formato esperado para a geração interna do boleto.

O que foi feito para resolver o problema hipotético?
	Para solucionar esse problema, foi aplicado o Adapter para fazer a conversão e tratamento dos dados externos para o PaymentSlipService realizar o processamento do boleto.o padrão singleton, garantindo um ponto de acesso único global e também que apenas uma instância da classe esteja disponível para a aplicação.	

# Design Pattern - Structural: Decorator
Problema Hipotético:
	Dado que o e-commerce precise enviar uma notificação para um software CRM a cada pedido processado contendo os dados da compra, precisaremos implementar o envio sem alterar as implementações de IPaymentService para realizar a chamada.

O que foi feito para resolver o problema hipotético?
	Imaginando o cenário em que a sincronização com o CRM possua uma interface própria, incluímos a interface ICoreCrmIntegrationService que possui o contrato do método Sync. Criamos a rota processOrderWithSyncToCrm na OrdersController para separar do fluxo padrão as orders que farão o envio para o CRM.
	Implementamos o decorator PaymentServiceDecorator, o qual herda a interface que vamos extender IPaymentService e na implementação do método Process, fazemos o envio da sincronização com o método Sync do service ICoreCrmIntegrationService, deste modo, conseguimos extender o método Process sem alterar a sua implementação original.

# Design Pattern - Structural: Facade
Problema Hipotético:
	Dado que o e-commerce precise fazer uma requisição http em uma rota terceira para verificar fraude antes do processamento. O processo para fazer essa requisição é complexo pela quantidade de objetos que precisam ser instânciados e configurados. Como tornar o processo mais simples nas classes clientes?

O que foi feito para resolver o problema hipotético?
	Para resolver esse problema hipotético, fizemos a implementação do design pattern structural facade, onde criamos a interface IAntiFraudFacade, a qual possui apenas a assinatura do método Check.
	Levamos para a implementação da interface todo o algorítimo que de fato faz a requisição e retorna o objeto desejado, deste modo, a classe cliente apenas instância a interface e faz a chamada simplificada do método Check;

# Observações Gerais
Os códigos implementados não possuem a injeção de dependência correta nos padrões do .NET 8, o intuíto do projeto é mostrar a implementação dos Design Patterns de forma mais simplificada e objetiva.

#Fontes
Curso: Formação arquitetura de software - LuisDev.
Livro: Padrões de projeto - Soluções reutilizáveis de software orientado a objetos;
Artigos: Refactoring Guru - https://refactoring.guru/pt-br/design-patterns