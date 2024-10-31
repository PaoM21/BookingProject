FROM mcr.microsoft.com/mssql/server:2019-latest AS sqlserver

# Create app directory
WORKDIR /usr/src/app

# Copy initialization scripts
COPY BookingProject.API/Db /usr/src/app
COPY entrypoint.sh .

# Set environment variables, not have to write them with the docker run command
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=abc.1234!
ENV MSSQL_DBNAME=Booking

EXPOSE 1433

# Run Microsoft SQL Server and initialization script (at the same time)
CMD /bin/bash ./entrypoint.sh
