FROM mcr.microsoft.com/dotnet/runtime:8.0-jammy AS runtime

RUN apt-get update && apt-get upgrade -y
COPY main/Editor/bin/Release/net8.0/publish /home
WORKDIR /home/
#ENTRYPOINT ["Editor"]
CMD Editor

