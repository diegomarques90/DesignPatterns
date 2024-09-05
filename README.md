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
	Primeiro trabalhamos com a ideia de separação de responsabilidades, onde, implementamos a interface IPaymentService apenas com o método Process que recebe um OrderInputModel.
	Após a definição da interface e seu contrato, implementamos os CreditCardService e PaymentSlipService, deste modo, cada tipo de forma de pagamento terá o seu próprio serviço com a sua implementação específica do processamento do pagamento.
	Concluída essa primeira etapa de refactor, podemos iniciar a implementação do DesignPattern Factory do tipo Creational.
	Criamos a interface IPaymentServiceFactory que tem por objetivo retornar o serviço correto de acordo com o PaymentMethod.
	Em seguida implementamos a interface no service PaymentServiceFactory, sendo assim, o PaymentServiceFactory baseado no PaymentMethod é que vai retornar o serviço específico para processar o pagamento.
	Por fim, na OrdersController, adicionamos a rota "withFactoryMethod" para processar o pagamento com a implementação do DesignPatter Factory Method do tipo Creational.
	
#Observações Gerais
Os códigos implementados não possuem a injeção de dependência correta nos padrões do .NET 8, o intuíto do projeto é mostrar a implementação dos Design Patterns de forma mais simplificada e objetiva.
