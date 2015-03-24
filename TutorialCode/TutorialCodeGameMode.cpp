// Copyright 1998-2015 Epic Games, Inc. All Rights Reserved.

#include "TutorialCode.h"
#include "TutorialCodeGameMode.h"
#include "TutorialCodeCharacter.h"

ATutorialCodeGameMode::ATutorialCodeGameMode(const FObjectInitializer& ObjectInitializer)
	: Super(ObjectInitializer)
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPerson/Blueprints/ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
