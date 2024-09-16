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
- Problema hipotético:

Dado que uma startup com e-commerce precisa processar seus pagamentos ao receber pedidos.
Dependendo da forma de pagamento o direcionamento do processamento será distinto e atualmente as formas de pagamento são: Cartão de Crédito ou boleto, porém, chegou a solicitação para implementar a forma de pagamento PIX.
No exemplo de controller sem a correção, o código é complexo e crescendo a cada nova implementação de forma de pagamento.

- O que foi feito para resolver o problema hipotético?
Primeiro trabalhamos com a ideia de separação de responsabilidades, onde, implementamos a interface IPaymentService apenas com o método Process que recebe um OrderInputModel.
Após a definição da interface e seu contrato, implementamos os CreditCardService e PaymentSlipService, deste modo, cada tipo de forma de pagamento terá o seu próprio serviço com a sua implementação específica do processamento do pagamento.
Concluída essa primeira etapa de refactor, podemos iniciar a implementação do DesignPattern Factory do tipo Creational.
Criamos a interface IPaymentServiceFactory que tem por objetivo retornar o serviço correto de acordo com o PaymentMethod.
Em seguida implementamos a interface no service PaymentServiceFactory, sendo assim, o PaymentServiceFactory baseado no PaymentMethod é que vai retornar o serviço específico para processar o pagamento.
Por fim, na OrdersController, adicionamos a rota "withFactoryMethod" para processar o pagamento com a implementação do DesignPatter Factory Method do tipo Creational.
	
# Design Pattern - Abstract Factory
- Problema Hipotético:
Dado que uma Startup de E-Commerce, possui a necessidade de implementar a restrinção do pagamento e envio dependendo da origem da compra (internacional ou local).
Condicional origem:
- Internacional: O pagamento deverá ser realizado apenas por cartão de crédito;
- Local: O pagamento poderá ser feito por cartão de crédito, débito ou boleto;
Cada condicional possuirá maneiras distintas para processar o envio.

O que foi feito para resolver o problema hipotético?
A ideia consiste em implementar o Abstract Factory para realizar a implementação e instânciação de um conjunto de objetos, que neste problema são:
- Objeto do Serviço de Pagamentos;
- Objeto do Serviço de Envio;
Sendo assim, começamos criando a interface IOrderAbstractFactory que possui o contrato para obter os serviços de pagamento e de entrega (IPaymentService e IDeliveryService).
Na sequência a interface foi implementada em duas classes (InternationalOrderAbstractFactory e NationalOrderAbstractFactory. As duas implementações possuem a injeção de dependência dos services que são necessários para realizar as operações do contrato. A diferença é que a InternationalOrderAbstractFactory possui a injeção de dependência direta do PaymentService e a NationalOrderAbstractFactory possui a injeção de dependência do PaymentServiceFactory. 
Isso ocorre por causa da regra de negócio mapeada no problema hipotético, pois, quando o pagamento é internacional, aceita-se apenas pagamentos no cartão de crédito e quando é nacional, aceita-se outras formas de pagamento, deste modo, é necessário utilizar o PaymentServiceFactory para retornar o serviço correto de acordo com a forma de pagamento. 
Por fim, na OrdersControler, implementamos a rota processOrderWithAbstractFactory, a qual faz a injeção de dependência das factories National e International para processar o pedido.


# Observações Gerais
Os códigos implementados não possuem a injeção de dependência correta nos padrões do .NET 8, o intuíto do projeto é mostrar a implementação dos Design Patterns de forma mais simplificada e objetiva.

