Funcionalidade: LoginFeature


	Cenario: 
		Dado Que o usuário esteja na página de login
		Quando Informar as credenciais corretamente
		Então Sera redirecionado para a tela de Produtos

	Cenario: 
		Dado Que o usuário esteja na página de login
		Quando Informas as credenciais "<incorretamente>"
		Então Será exibida uma mensagem informando o erro


