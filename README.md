# Sobre o projeto DesignPatterns.Creational
O projeto foi criado durante a formação Arquitetura de Software do LuisDev.
O objetivo do projeto é trazer exemplos práticos da resolução de problemas comuns do desenvolvimento de software com a utilização de Design Patterns do tipo Creational.

# O que são Design Patterns - Creational?
De forma bem resumida, são patterns que lidam com mecanismos de criação de instâncias de objetos.
O objetivo é melhorar a maneira de criação de instâncias, reduzindo a complexidade envolvida.
Vale salientar que, os problemas é quem guiam a escolha do pattern e nunca o contrário.

# Estrutura do projeto
No projeto, você encontrará exemplos práticos da utilização dos patterns do tipo Creational para solucionar os problemas hipotéticos.
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

# Design Pattern - Abstract Factory
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

# Design Pattern - Builder
Problema Hipotético:
	Dado o fato que a Startup de E-Commerce possui a necessidade da geração de boletos e que cada boleto possuíra suas próprias características, sendo:
		Nosso número, código do cedente, cedente, pagador, data de vencimento, data de emissão e entre outras;
	A construção deste objeto Boleto, possui bastantes condicionais e variações, portanto, o ideal é utilizarmos o padrão builder para organizar a construção do objeto por etapas.
		
O que foi feito para resolver o problema hipotético?
	Criamos a classe PaymentSlipBuilder e implementamos o padrão builder, criando os métodos que farão o preenchimento das informações por etapas.
	Em seguida, instânciamos a classe PaymentSlipBuilder no serviço de geração dos boletos e contruímos o objeto de boleto de acordo com a necessidade, chamando as etapas.

# Observações Gerais
Os códigos implementados não possuem a injeção de dependência correta nos padrões do .NET 8, o intuíto do projeto é mostrar a implementação dos Design Patterns de forma mais simplificada e objetiva.

#Fontes
Curso: Formação arquitetura de software - LuisDev.
Livro: Padrões de projeto - Soluções reutilizáveis de software orientado a objetos;
Artigos: Refactoring Guru - https://refactoring.guru/pt-br/design-patterns